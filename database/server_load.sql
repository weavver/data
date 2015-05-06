
CREATE ASSEMBLY [Weavver.DAL] FROM '%dalpath%' WITH PERMISSION_SET = SAFE;
GO

CREATE FUNCTION [dbo].[YearMonth](@dt DATETIME)
     RETURNS DATETIME AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[YearMonth]
GO
CREATE FUNCTION [dbo].[Account_AccountBalances_GetRelativeBalance] (@b1 TINYINT)
     RETURNS MONEY AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[Account_AccountBalances_GetRelativeBalance]
GO
CREATE FUNCTION [dbo].[Accounting_RecurringBillables_UnbilledAmount] (@startDate DATETIME, @position DATETIME, @endAt DATETIME, @amount NUMERIC (18), @billingDirection NVARCHAR)
     RETURNS NUMERIC (18) AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[Accounting_RecurringBillables_UnbilledAmount]
GO
CREATE FUNCTION [dbo].[Accounting_RecurringBillables_UnbilledPeriods] (@startDate DATETIME, @position DATETIME, @endAt DATETIME, @billingDirection NVARCHAR)
     RETURNS INT AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[Accounting_RecurringBillables_UnbilledPeriods]
GO
CREATE FUNCTION [dbo].[Total_ForLedger] (@organizationId UNIQUEIDENTIFIER, @accountId UNIQUEIDENTIFIER, @ledgerType NVARCHAR (4000), @includeCredits BIT, @includeDebits BIT, @includeReservedFunds BIT, @startDate DATETIME, @endDate DATETIME, @includeItemsOnEndDate bit)
     RETURNS DECIMAL (18, 2) AS EXTERNAL NAME [Weavver.DAL].[StoredProcedures].[Total_ForLedger]
GO
CREATE FUNCTION [dbo].[GetName] (@id UNIQUEIDENTIFIER)
     RETURNS NVARCHAR (4000) AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[GetName]
GO
CREATE FUNCTION [dbo].[LocalizeDT] (@dt DATETIME)
     RETURNS DATETIME AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[LocalizeDT]
GO
CREATE FUNCTION [dbo].[HR_TimeLogs_TimeSpan] (@startAt DATETIME, @endAt DATETIME)
     RETURNS FLOAT AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[HR_TimeLogs_TimeSpan]
GO
CREATE FUNCTION [dbo].[Sales_LicenseKeys_Activations] (@licenseKeyId UNIQUEIDENTIFIER)
     RETURNS INT AS EXTERNAL NAME [Weavver.DAL].[UserDefinedFunctions].[Sales_LicenseKeys_Activations]
GO
--CREATE FUNCTION [dbo].[StoredProcedures_HttpPost] (@licenseKeyId UNIQUEIDENTIFIER)
--     RETURNS INT AS EXTERNAL NAME [Weavver.DAL].[StoredProcedures].[StoredProcedures_HttpPost]
--GO
CREATE FUNCTION dbo.Accounting_Statements_EnteredTotal(@organizationId uniqueidentifier, @accountId uniqueidentifier, @includeCredits bit, @includeDebits bit, @includeProjections bit, @startAt DATETIME, @endAt DATETIME, @includeItemsOnEndDate BIT)
RETURNS decimal(12, 2)
AS 
BEGIN

	declare @ledgerType varchar(max)
	select @ledgerType = (select TOP 1 ledgertype from accounting_accounts where id=@accountId)

	declare @total decimal(12, 2)
	select @total = [dbo].[Total_ForLedger](@organizationId, @accountId, @ledgerType, @includeCredits, @includeDebits, @includeProjections, @startAt, @endAt, @includeItemsOnEndDate)

	return @total
END
GO


--###################################################################################################################################
--##                                                     COMPUTED COLUMNS                                                          ##
--###################################################################################################################################

ALTER TABLE Accounting_Accounts ADD Balance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,0,null,null,0))
ALTER TABLE Accounting_Accounts ADD AvailableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,1,null,null,0))
--ALTER TABLE Accounting_RecurringBillables ADD AccountFromName AS (dbo.GetName(AccountFrom))
--ALTER TABLE Accounting_RecurringBillables ADD AccountToName AS (dbo.GetName(AccountTo))
ALTER TABLE Accounting_Checks ADD PayeeName AS (dbo.GetName(Payee))
ALTER TABLE Accounting_LedgerItems ADD AccountName AS (dbo.GetName(AccountId))
Alter TABLE Accounting_Reconciliations ADD EnteredStartingBalance as (dbo.Accounting_Statements_EnteredTotal(OrganizationId, Account, 1, 1, 0, null, StartAt, 0))
ALTER TABLE Accounting_Reconciliations ADD EnteredCredits as (dbo.Accounting_Statements_EnteredTotal(OrganizationId, Account, 1, 0, 0, StartAt, EndAt, 1))
ALTER TABLE Accounting_Reconciliations ADD EnteredDebits as (dbo.Accounting_Statements_EnteredTotal(OrganizationId, Account, 0, 1, 0, StartAt, EndAt, 1))
ALTER TABLE Accounting_Reconciliations ADD EnteredEndingBalance as (dbo.Accounting_Statements_EnteredTotal(OrganizationId, Account, 1, 1, 0, null, EndAt, 1))
ALTER TABLE Accounting_RecurringBillables ADD UnbilledPeriods AS (dbo.Accounting_RecurringBillables_UnbilledPeriods(StartAt,Position,EndAt,BillingDirection))
ALTER TABLE Accounting_RecurringBillables ADD UnbilledAmount AS (dbo.Accounting_RecurringBillables_UnbilledAmount(StartAt,Position,EndAt,Amount,BillingDirection))
ALTER TABLE HR_TimeLogs ADD Duration AS (dbo.HR_TimeLogs_TimeSpan(Start, [End]))
ALTER TABLE Logistics_Organizations ADD PayableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Payable',1,1,1,null,null,0))
ALTER TABLE Logistics_Organizations ADD ReceivableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Receivable',1,1,1,null,null,0))
ALTER TABLE Sales_LicenseKeys ADD Activations AS (dbo.Sales_LicenseKeys_Activations(Id))
ALTER TABLE Sales_Orders ADD Total AS ([dbo].[Total_ForLedger]([OrganizationId],[Id],'Receivable',(1),(1),(0),NULL,NULL,0))
ALTER TABLE Sales_ShoppingCartItems ADD Total AS ((([UnitCost]+[SetUp])+[Deposit]+[Monthly])*[Quantity])

GO
IF OBJECT_ID ('Accounting_OrganizationPnL_ByMonth', 'V') IS NOT NULL
DROP VIEW Accounting_OrganizationPnL_ByMonth
GO
CREATE VIEW
     Accounting_OrganizationPnL_ByMonth
AS
select OrganizationId,
year(dbo.LocalizeDT(PostAt)) as 'Year',
month(dbo.LocalizeDT(PostAt)) as 'M',
     isnull((select sum(amount) from Accounting_LedgerItems li1
          where
            li1.OrganizationId = li.OrganizationId and
          li1.LedgerType = 'Receivable' and
            li1.Code='Sale' and
          month(dbo.LocalizeDT(li1.PostAt)) = month(dbo.LocalizeDT(li.PostAt)) and
          year(dbo.LocalizeDT(li1.PostAt)) = year(dbo.LocalizeDT(li.PostAt))
          ), 0) - 
     isnull((select sum(amount) from Accounting_LedgerItems li2
               where
                 li2.OrganizationId = li.OrganizationId and
                 li2.LedgerType = 'Payable' and
                 li2.Code='Purchase' and
                 month(dbo.LocalizeDT(li2.PostAt)) = month(dbo.LocalizeDT(li.PostAt)) and
                 year(dbo.LocalizeDT(li2.PostAt)) = year(dbo.LocalizeDT(li.PostAt))
            ), 0) as 'Balance'
from Accounting_LedgerItems li
Group By OrganizationId,
year(dbo.LocalizeDT(PostAt)),
month(dbo.LocalizeDT(PostAt))
GO


--CREATE PROCEDURE StoredProcedures_HttpPost @messageBody NVARCHAR(MAX)
--AS
--     -- Begin Dialog using service on contract
--     DECLARE @SBDialog uniqueidentifier
--     BEGIN DIALOG CONVERSATION @SBDialog
--          FROM SERVICE SBSendService
--          TO SERVICE 'HttpReceiveService'
--          ON CONTRACT SBHttpContract
--          WITH ENCRYPTION = OFF;
--     SEND ON CONVERSATION @SBDialog
--          MESSAGE TYPE SBMessage (@messageBody)
--GO

--IF NOT EXISTS (SELECT * FROM sys.service_queues WHERE name = 'HttpPostReceiveQueue')
--     BEGIN CREATE QUEUE HttpPostReceiveQueue WITH STATUS=OFF, RETENTION=ON; END;

--ALTER QUEUE HttpPostReceiveQueue
--    WITH STATUS = ON,
--         ACTIVATION
--         (
--           STATUS = ON,
--           PROCEDURE_NAME = StoredProcedures.HttpPost,
--           MAX_QUEUE_READERS = 10,
--           EXECUTE AS SELF
--         );
GO