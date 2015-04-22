
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'Balance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN Balance END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'AvailableBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN AvailableBalance END

--if EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'BankBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN AvailableBalance END
--if EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Accounts') and Name = N'BankAvailableBalance') BEGIN ALTER TABLE Accounting_Accounts DROP COLUMN BankAvailableBalance END

IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_Checks') and Name = N'PayeeName') BEGIN ALTER TABLE Accounting_Checks DROP COLUMN PayeeName END
IF EXISTS(select * from Sys.Columns where Object_ID = Object_ID(N'Accounting_LedgerItems') and Name = N'AccountName') BEGIN ALTER TABLE Accounting_LedgerItems DROP COLUMN AccountName END

IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Reconciliations') and Name = N'EnteredStartingBalance') BEGIN ALTER TABLE Accounting_Reconciliations DROP COLUMN EnteredStartingBalance END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Reconciliations') and Name = N'EnteredCredits') BEGIN ALTER TABLE Accounting_Reconciliations DROP COLUMN EnteredCredits END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Reconciliations') and Name = N'EnteredDebits') BEGIN ALTER TABLE Accounting_Reconciliations DROP COLUMN EnteredDebits END
IF EXISTS(select * from sys.columns where Object_ID = Object_ID(N'Accounting_Reconciliations') and Name = N'EnteredEndingBalance') BEGIN ALTER TABLE Accounting_Reconciliations DROP COLUMN EnteredEndingBalance END

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
IF OBJECT_ID('[Accounting_Statements_EnteredTotal]') IS NOT NULL DROP FUNCTION [dbo].Accounting_Statements_EnteredTotal;
IF OBJECT_ID('[GetName]') IS NOT NULL DROP FUNCTION [dbo].[GetName];
IF OBJECT_ID('[LocalizeDT]') IS NOT NULL DROP FUNCTION [dbo].[LocalizeDT];
IF OBJECT_ID('[HR_TimeLogs_TimeSpan]') IS NOT NULL DROP FUNCTION [dbo].[HR_TimeLogs_TimeSpan];
IF OBJECT_ID('[Total_ForLedger]') IS NOT NULL DROP FUNCTION [dbo].[Total_ForLedger];
IF OBJECT_ID('[Sales_LicenseKeys_Activations]') IS NOT NULL DROP FUNCTION [dbo].[Sales_LicenseKeys_Activations];
IF OBJECT_ID('[StoredProcedures_HttpPost]') IS NOT NULL DROP PROCEDURE [dbo].[StoredProcedures_HttpPost];
GO

IF EXISTS (SELECT * FROM sys.assemblies asms WHERE asms.name = N'Weavver.DAL')
     DROP ASSEMBLY [Weavver.DAL]
GO
