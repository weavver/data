

IF EXISTS(select * FROM sys.views where name = 'Accounting_AccountBalances')
begin
     DROP VIEW Accounting_AccountBalances
end

GO

CREATE VIEW [dbo].[Accounting_AccountBalances]
as
Select OrganizationId, AccountId, LedgerType, dbo.GetName(AccountId) as 'AccountName',
	isnull((select sum(amount) from Accounting_LedgerItems li1
			where
				li1.AccountId = li.AccountId and
				li1.LedgerType=li.LedgerType and
				li1.PostAt <= getdate()), 0)
       as Balance
From Accounting_LedgerItems li
Group By OrganizationId, LedgerType, AccountId

GO
