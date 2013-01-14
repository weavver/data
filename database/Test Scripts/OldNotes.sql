

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

