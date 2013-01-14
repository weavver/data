

ALTER TABLE Accounting_Accounts
     ADD Balance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,0,null,null))

ALTER TABLE Accounting_Accounts
     ADD AvailableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,LedgerType,1,1,1,null,null))

ALTER TABLE Accounting_RecurringBillables
     ADD UnbilledPeriods AS (dbo.Accounting_RecurringBillables_UnbilledPeriods(StartAt,Position,EndAt))

ALTER TABLE Accounting_RecurringBillables
     ADD UnbilledAmount AS (dbo.Accounting_RecurringBillables_UnbilledAmount(StartAt,Position,EndAt,Amount))

ALTER TABLE Sales_ShoppingCartItems
     ADD Total AS ((([UnitCost]+[SetUp])+[Deposit]+[Monthly])*[Quantity])

ALTER TABLE Sales_Orders
     ADD Total AS ([dbo].[Total_ForLedger]([OrganizationId],[Id],'Receivable',(1),(1),(0),NULL,NULL))

--ALTER TABLE Accounting_RecurringBillables
--    ADD AccountFromName AS (dbo.GetName(AccountFrom))

--ALTER TABLE Accounting_RecurringBillables
--    ADD AccountToName AS (dbo.GetName(AccountTo))

ALTER TABLE Accounting_LedgerItems
    ADD AccountName AS (dbo.GetName(AccountId))

ALTER TABLE HR_TimeLogs
    ADD Duration AS (dbo.HR_TimeLogs_TimeSpan(Start, [End]))

ALTER TABLE Sales_LicenseKeys
    ADD Activations AS (dbo.Sales_LicenseKeys_Activations(Id))


--GO
--IF OBJECT_ID ('Accounting_AccountBalances', 'V') IS NOT NULL
--     DROP VIEW Accounting_AccountBalances
--GO
--CREATE VIEW
--	Accounting_AccountBalances
--as
--select OrganizationId, AccountId, LedgerType, dbo.GetName(AccountId) as 'AccountName',
--	isnull((select sum(amount) from Accounting_LedgerItems li1
--			where
--				li1.AccountId = li.AccountId and
--				li1.EntryType='Credit' and
--				li1.LedgerType=li.LedgerType and
--				li1.PostAt <= getdate()), 0) - 
--	isnull((select sum(amount) from Accounting_LedgerItems li1
--			where
--				li1.AccountId = li.AccountId and
--				li1.EntryType='Debit' and
--				li1.LedgerType=li.LedgerType and
--				li1.PostAt <= getdate()), 0)
--       as Balance
-- from Accounting_LedgerItems li
-- Group By OrganizationId, LedgerType, AccountId


ALTER TABLE Logistics_Organizations
     ADD PayableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Payable',1,1,1,null,null))

ALTER TABLE Logistics_Organizations
     ADD ReceivableBalance AS (dbo.Total_ForLedger(OrganizationId,Id,'Receivable',1,1,1,null,null))


GO
IF OBJECT_ID ('Accounting_OrganizationPnL_ByMonth', 'V') IS NOT NULL
DROP VIEW Accounting_OrganizationPnL_ByMonth
GO
CREATE VIEW
	Accounting_OrganizationPnL_ByMonth
as
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