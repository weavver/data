

use weavverstaging

if Exists(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts')
                                           and Name = N'Balance')
begin
     ALTER TABLE Accounting_Accounts
        DROP COLUMN Balance
end

if Exists(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts')
                                       and Name = N'AvailableBalance')
begin
     ALTER TABLE Accounting_Accounts
        DROP COLUMN AvailableBalance
end

--if Exists(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts')
--                                       and Name = N'BankBalance')
--begin
--     ALTER TABLE Accounting_Accounts
--        DROP COLUMN AvailableBalance
--end

--if Exists(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts')
--                                       and Name = N'BankAvailableBalance')
--begin
--     ALTER TABLE Accounting_Accounts
--        DROP COLUMN BankAvailableBalance
--end


if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'Accounting_RecurringBillables')
          and Name = N'UnbilledPeriods')
begin
     ALTER TABLE Accounting_RecurringBillables
        DROP COLUMN UnbilledPeriods
end

if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'Accounting_RecurringBillables')
          and Name = N'UnbilledAmount')
begin
     ALTER TABLE Accounting_RecurringBillables
        DROP COLUMN UnbilledAmount
end


--if Exists(select * from sys.columns
--          where Object_ID = Object_ID(N'Accounting_RecurringBillables')
--          and Name = N'AccountFromName')
--begin
--     ALTER TABLE Accounting_RecurringBillables
--        DROP COLUMN AccountFromName
--end


--if Exists(select * from sys.columns
--          where Object_ID = Object_ID(N'Accounting_RecurringBillables')
--          and Name = N'AccountToName')
--begin
--     ALTER TABLE Accounting_RecurringBillables
--        DROP COLUMN AccountToName
--end


if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'Accounting_LedgerItems')
          and Name = N'AccountName')
begin
     ALTER TABLE Accounting_LedgerItems
        DROP COLUMN AccountName
end


if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'Sales_ShoppingCartItems')
          and Name = N'Total')
begin
     ALTER TABLE Sales_ShoppingCartItems
        DROP COLUMN Total
end


if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'Sales_Orders')
          and Name = N'Total')
begin
     ALTER TABLE Sales_Orders
        DROP COLUMN Total
end

if Exists(select * from sys.columns
          where Object_ID = Object_ID(N'HR_TimeLogs')
          and Name = N'Duration')
begin
     ALTER TABLE HR_TimeLogs
        DROP COLUMN Duration
end


if Exists(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations')
                                       and Name = N'PayableBalance')
begin
     ALTER TABLE Logistics_Organizations
        DROP COLUMN PayableBalance
end


if Exists(select * from Sys.Columns where Object_ID = Object_ID(N'Logistics_Organizations')
                                       and Name = N'ReceivableBalance')
begin
     ALTER TABLE Logistics_Organizations
        DROP COLUMN ReceivableBalance
end



if Exists(select * from Sys.Columns where Object_ID = Object_ID(N'Sales_LicenseKeys')
                                       and Name = N'Activations')
begin
     ALTER TABLE Sales_LicenseKeys
        DROP COLUMN Activations
end

-------------------------------------------------------------------------------------------
-- ADD A CALCULATED BALANCE COLUMN TO THE ORDER TABLE
--decimal arbalance = Accounting.Balance_ForLedger(LedgerType.Receivable, SelectedOrganization.Id, itemId, null, null);