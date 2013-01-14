using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
     [Microsoft.SqlServer.Server.SqlFunction]
     public static SqlMoney Account_AccountBalances_GetRelativeBalance(SqlByte b1)
     {
          switch ((int) b1)
          {
               case 1:

               case 2:

               case 3:

               case 4:

               case 5:
                    break;
          }
          // Put your code here
          return new SqlMoney(0m);
     }
}

