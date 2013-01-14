using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
//-------------------------------------------------------------------------------------------
     // returns total seconds
     [Microsoft.SqlServer.Server.SqlFunction]
     public static SqlDouble HR_TimeLogs_TimeSpan(SqlDateTime startAt, SqlDateTime endAt)
     {
          if (endAt.IsNull || startAt.IsNull)
               return new SqlDouble();

          TimeSpan duration = endAt.Value.Subtract(startAt.Value);
          return new SqlDouble(duration.TotalSeconds);
     }
//-------------------------------------------------------------------------------------------
}