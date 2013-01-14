using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
//-------------------------------------------------------------------------------------------
     [Microsoft.SqlServer.Server.SqlFunction]
     public static SqlInt32 Accounting_RecurringBillables_UnbilledPeriods(SqlDateTime startDate, SqlDateTime position, SqlDateTime endAt)
     {
          DateTime utcNow = DateTime.UtcNow; // record the current moment
          DateTime utcPosition = position.Value.ToUniversalTime();
          DateTime utcMaxPosition = (!endAt.IsNull) ? endAt.Value.ToUniversalTime() : utcNow;
          if (utcNow >= utcPosition && utcPosition <= utcMaxPosition)
          {
               int monthsNewPos = (utcMaxPosition.Year * 12) + utcMaxPosition.Month;
               int monthsOldPos = (utcPosition.Year * 12) + utcPosition.Month;
               int periods = monthsNewPos - monthsOldPos + 1;
               return new SqlInt32(periods);
          }
          else
          {
               return new SqlInt32(0);
          }
     }
//-------------------------------------------------------------------------------------------
     [Microsoft.SqlServer.Server.SqlFunction]
     public static SqlDecimal Accounting_RecurringBillables_UnbilledAmount(SqlDateTime startDate, SqlDateTime position, SqlDateTime endAt, Decimal amount)
     {
          SqlInt32 unbilledPeriods = Accounting_RecurringBillables_UnbilledPeriods(startDate, position, endAt);
          return new SqlDecimal(unbilledPeriods.Value * amount);
     }
//-------------------------------------------------------------------------------------------
};

