GO
sp_configure 'show advanced options', 1;
GO
RECONFIGURE;
GO
sp_configure 'clr enabled', 1;
GO
RECONFIGURE;
GO

-- Is this enabled?
-- ALTER DATABASE WEAVVERDB SET ENABLE_BROKER; 

IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'Balance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN Balance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'AvailableBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN AvailableBalance END

--if EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'BankBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN AvailableBalance END
--if EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'BankAvailableBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN BankAvailableBalance END

IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Checks') and Name = N'PayeeName') BEGIN ALTER TABLE Accounting_Checks DROP COLUMN PayeeName END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_LedgerItems') and Name = N'AccountName') BEGIN ALTER TABLE Accounting_Checks DROP COLUMN AccountName END

IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_RecurringBillables') and Name = N'UnbilledPeriods') BEGIN ALTER TABLE Accounting_RecurringBillables DROP COLUMN UnbilledPeriods END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_RecurringBillables') and Name = N'UnbilledAmount') BEGIN ALTER TABLE Accounting_RecurringBillables DROP COLUMN UnbilledAmount END

--IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_RecurringBillables') and Name = N'AccountFromName') BEGIN ALTER TABLE Accounting_RecurringBillables DROP COLUMN AccountFromName END
--IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_RecurringBillables') and Name = N'AccountToName') BEGIN ALTER TABLE Accounting_RecurringBillables DROP COLUMN AccountToName END

IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_LedgerItems') and Name = N'AccountName') BEGIN ALTER TABLE Accounting_LedgerItems DROP COLUMN AccountName END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Sales_ShoppingCartItems') and Name = N'Total') BEGIN ALTER TABLE Sales_ShoppingCartItems DROP COLUMN Total END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Sales_Orders') and Name = N'Total') BEGIN ALTER TABLE Sales_Orders DROP COLUMN Total END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'HR_TimeLogs') and Name = N'Duration') BEGIN ALTER TABLE HR_TimeLogs DROP COLUMN Duration END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'PayableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN PayableBalance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations') and Name = N'ReceivableBalance') BEGIN ALTER TABLE Logistics_Organizations DROP COLUMN ReceivableBalance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Sales_LicenseKeys') and Name = N'Activations') BEGIN ALTER TABLE Sales_LicenseKeys DROP COLUMN Activations END

IF OBJECT_ID('[YearMonth]') IS NOT NULL DROP FUNCTION [dbo].[YearMonth];
IF OBJECT_ID('[Account_AccountBalances_GetRelativeBalance]') IS NOT NULL DROP FUNCTION [dbo].[Account_AccountBalances_GetRelativeBalance];
IF OBJECT_ID('[Accounting_RecurringBillables_UnbilledAmount]') IS NOT NULL DROP FUNCTION [dbo].[Accounting_RecurringBillables_UnbilledAmount];
IF OBJECT_ID('[Accounting_RecurringBillables_UnbilledPeriods]') IS NOT NULL DROP FUNCTION [dbo].[Accounting_RecurringBillables_UnbilledPeriods];
IF OBJECT_ID('[GetName]') IS NOT NULL DROP FUNCTION [dbo].[GetName];
IF OBJECT_ID('[LocalizeDT]') IS NOT NULL DROP FUNCTION [dbo].[LocalizeDT];
IF OBJECT_ID('[HR_TimeLogs_TimeSpan]') IS NOT NULL DROP FUNCTION [dbo].[HR_TimeLogs_TimeSpan];
IF OBJECT_ID('[Total_ForLedger]') IS NOT NULL DROP FUNCTION [dbo].[Total_ForLedger];
IF OBJECT_ID('[Sales_LicenseKeys_Activations]') IS NOT NULL DROP FUNCTION [dbo].[Sales_LicenseKeys_Activations];
IF OBJECT_ID('[StoredProcedures_HttpPost]') IS NOT NULL DROP FUNCTION [dbo].[StoredProcedures_HttpPost];
IF OBJECT_ID('[QueueHttpPost]') IS NOT NULL DROP PROCEDURE [dbo].[QueueHttpPost];
GO

IF EXISTS (SELECT * FROM sys.assemblies asms WHERE asms.name = N'Weavver.DAL')
     DROP ASSEMBLY [Weavver.DAL]
GO

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
CREATE FUNCTION [dbo].[Total_ForLedger] (@organizationId UNIQUEIDENTIFIER, @accountId UNIQUEIDENTIFIER, @ledgerType NVARCHAR (4000), @includeCredits BIT, @includeDebits BIT, @includeReservedFunds BIT, @startDate DATETIME, @endDate DATETIME)
     RETURNS NUMERIC (18, 2) AS EXTERNAL NAME [Weavver.DAL].[StoredProcedures].[Total_ForLedger]
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
CREATE FUNCTION [dbo].[StoredProcedures_HttpPost] (@licenseKeyId UNIQUEIDENTIFIER)
     RETURNS INT AS EXTERNAL NAME [Weavver.DAL].[StoredProcedures].[StoredProcedures_HttpPost]
GO

ALTER TABLE Accounting_Accounts ADD Balance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,0,null,null))
ALTER TABLE Accounting_Accounts ADD AvailableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,1,null,null))
--ALTER TABLE Accounting_RecurringBillables ADD AccountFromName AS (dbo.GetName(AccountFrom))
--ALTER TABLE Accounting_RecurringBillables ADD AccountToName AS (dbo.GetName(AccountTo))
ALTER TABLE Accounting_Checks ADD PayeeName AS (dbo.GetName(Payee))
ALTER TABLE Accounting_LedgerItems ADD AccountName AS (dbo.GetName(AccountId))
ALTER TABLE Accounting_RecurringBillables ADD UnbilledPeriods AS (dbo.Accounting_RecurringBillables_UnbilledPeriods(StartAt,Position,EndAt,BillingDirection))
ALTER TABLE Accounting_RecurringBillables ADD UnbilledAmount AS (dbo.Accounting_RecurringBillables_UnbilledAmount(StartAt,Position,EndAt,Amount,BillingDirection))
ALTER TABLE HR_TimeLogs ADD Duration AS (dbo.HR_TimeLogs_TimeSpan(Start, [End]))
ALTER TABLE Logistics_Organizations ADD PayableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Payable',1,1,1,null,null))
ALTER TABLE Logistics_Organizations ADD ReceivableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Receivable',1,1,1,null,null))
ALTER TABLE Sales_LicenseKeys ADD Activations AS (dbo.Sales_LicenseKeys_Activations(Id))
ALTER TABLE Sales_Orders ADD Total AS ([dbo].[Total_ForLedger]([OrganizationId],[Id],'Receivable',(1),(1),(0),NULL,NULL))
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


CREATE PROCEDURE QueueHttpPost @messageBody NVARCHAR(MAX)
AS
     -- Begin Dialog using service on contract
     DECLARE @SBDialog uniqueidentifier
     BEGIN DIALOG CONVERSATION @SBDialog
          FROM SERVICE SBSendService
          TO SERVICE 'HttpReceiveService'
          ON CONTRACT SBHttpContract
          WITH ENCRYPTION = OFF;
     SEND ON CONVERSATION @SBDialog
          MESSAGE TYPE SBMessage (@messageBody)
GO

IF NOT EXISTS (SELECT * FROM sys.service_queues WHERE name = 'HttpPostReceiveQueue')
     BEGIN CREATE QUEUE HttpPostReceiveQueue WITH STATUS=OFF, RETENTION=ON; END;

ALTER QUEUE HttpPostReceiveQueue
    WITH STATUS = ON,
         ACTIVATION
         (
           STATUS = ON,
           PROCEDURE_NAME = StoredProcedures_HttpPost,
           MAX_QUEUE_READERS = 10,
           EXECUTE AS SELF
         );
GO