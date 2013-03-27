

---- Here we changed the LegerType column from a string to intger type
--update accounting_ledgeritems set ledgertype=0 where ledgertype='Payable'
--update accounting_ledgeritems set ledgertype=1 where ledgertype='Receivable'
--update accounting_ledgeritems set ledgertype=2 where ledgertype='Checking'
--update accounting_ledgeritems set ledgertype=3 where ledgertype='Savings'
--update accounting_ledgeritems set ledgertype=4 where ledgertype='CreditCard'
--update accounting_ledgeritems set ledgertype=5 where ledgertype='CreditLine'
--update accounting_ledgeritems set ledgertype=6 where ledgertype='MoneyMarket'
--update accounting_ledgeritems set ledgertype=7 where ledgertype='Holding'
--alter table accounting_ledgeritems alter column ledgertype tinyint not null

--exec sp_RENAME 'Accounting_Accounts.AccountType', 'LedgerType', 'COLUMN'

---- Here we changed the LegerType column from a string to intger type

--update accounting_accounts set ledgertype='Payable' where ledgertype='0'
--update accounting_accounts set ledgertype='Receivable' where ledgertype='1'
--update accounting_accounts set ledgertype='Checking' where ledgertype='2'
--update accounting_accounts set ledgertype='Savings' where ledgertype='3'
--update accounting_accounts set ledgertype='CreditCard' where ledgertype='4'
--update accounting_accounts set ledgertype='CreditLine' where ledgertype='5'
--update accounting_accounts set ledgertype='MoneyMarket' where ledgertype='6'
--update accounting_accounts set ledgertype='Holding' where ledgertype='7'


--update accounting_ledgeritems set ledgertype='Payable' where ledgertype='0'
--update accounting_ledgeritems set ledgertype='Receivable' where ledgertype='1'
--update accounting_ledgeritems set ledgertype='Checking' where ledgertype='2'
--update accounting_ledgeritems set ledgertype='Savings' where ledgertype='3'
--update accounting_ledgeritems set ledgertype='CreditCard' where ledgertype='4'
--update accounting_ledgeritems set ledgertype='CreditLine' where ledgertype='5'
--update accounting_ledgeritems set ledgertype='MoneyMarket' where ledgertype='6'
--update accounting_ledgeritems set ledgertype='Holding' where ledgertype='7'


-------------------------------------------------------------------------------------------
-- ADD A CALCULATED BALANCE COLUMN TO THE ORDER TABLE
--decimal arbalance = Accounting.Balance_ForLedger(LedgerType.Receivable, SelectedOrganization.Id, itemId, null, null);
-------------------------------------------------------------------------------------------
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

-------------------------------------------------------------------------------------------

--select dbo.OFXSync()

--GRANT EXTERNAL ACCESS ASSEMBLY TO wvvrDal

--ALTER DATABASE weavverstaging SET TRUSTWORTHY ON;

--ALTER AUTHORIZATION on DATABASE::[weavverstaging] to [wvvrDal]

--EXEC dbo.sp_changedbowner @loginame = N'sa', @map = false

--CREATE ASSEMBLY SystemWeb from 'C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll' with permission_set = unsafe
--CREATE ASSEMBLY InEBank FROM 'C:\Program Files (x86)\nsoftware\E-Banking Integrator V3 .NET Edition\lib\nsoftware.InEBankWeb.dll'
--CREATE ASSEMBLY WeavverLib FROM 'C:\Weavver\Main\Projects\WeavverLib\bin\Debug\WeavverLib.dll' with permission_set=unsafe

-- "C:\Weavver\Main\Projects\Console\bin\Debug\WeavverConsole.exe" --ofx-sync