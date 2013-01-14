


DROP FUNCTION Total_ForLedger
DROP FUNCTION YearMonth
DROP FUNCTION Account_AccountBalances_GetRelativeBalance
DROP FUNCTION Accounting_RecurringBillables_UnbilledAmount
DROP FUNCTION Accounting_RecurringBillables_UnbilledPeriods
DROP FUNCTION HR_TimeLogs_TimeSpan
DROP FUNCTION GetName
DROP FUNCTION LocalizeDT


DROP ASSEMBLY WeavverDAL


CREATE ASSEMBLY WeavverDAL FROM 'W:\Projects\Weavver\Main\Projects\Database Components\bin\Release\WeavverDAL.dll' WITH PERMISSION_SET = SAFE;

CREATE PROCEDURE Total_ForLedger AS EXTERNAL NAME UserDefinedFunctions.Total_ForLedger
CREATE PROCEDURE YearMonth
CREATE PROCEDURE Account_AccountBalances_GetRelativeBalance
CREATE PROCEDURE Accounting_RecurringBillables_UnbilledAmount
CREATE PROCEDURE Accounting_RecurringBillables_UnbilledPeriods
CREATE PROCEDURE HR_TimeLogs_TimeSpan
CREATE PROCEDURE GetName
CREATE PROCEDURE LocalizeDT