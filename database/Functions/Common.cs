using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
     //public const double SALES_TAX = .086;
//-------------------------------------------------------------------------------------------
     [SqlFunction(DataAccess = DataAccessKind.Read)]
     public static SqlString GetName(SqlGuid id)
     {
          string val = "";
          SqlConnection connection = new SqlConnection("context connection=true");
          connection.Open();
          GetFieldFromTable(connection, id, "Firstname,LastName", "System_Users", ref val);
          GetFieldFromTable(connection, id, "Name", "Logistics_Organizations", ref val);
          GetFieldFromTable(connection, id, "FirstName,LastName", "HR_Staff", ref val);
          GetFieldFromTable(connection, id, "Name", "Accounting_Accounts", ref val);
          GetFieldFromTable(connection, id, "Memo", "Accounting_LedgerItems", ref val);
          GetFieldFromTable(connection, id, "PrimaryContactNameFirst,PrimaryContactNameLast", "Sales_Orders", ref val);
          GetFieldFromTable(connection, id, "Name", "Logistics_Addresses", ref val);
          GetFieldFromTable(connection, id, "Right(Number, 4) as 'Number'", "Accounting_CreditCards", ref val);
          GetFieldFromTable(connection, id, "SUBSTRING(Memo, 1, 10) as 'Memo', '- ARB Rule' as 'ARB'", "Accounting_RecurringBillables", ref val);
          GetFieldFromTable(connection, id, "Name", "Logistics_Features", ref val);
          return val ?? "";
     }
//-------------------------------------------------------------------------------------------
     public static void GetFieldFromTable(SqlConnection connection, SqlGuid id, string fields, string tablename, ref string val)
     {
          if (val == null || val.Trim() == "")
          {
               string sql = "select top 1 " + fields + " from " + tablename + " where id=@id";
               using (SqlCommand command = new SqlCommand(sql, connection))
               {
                    command.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                         for (int i = 0; i < reader.FieldCount; i++)
                         {
                              val += reader[i].ToString();
                              if (i < reader.FieldCount - 1)
                              {
                                   val += " "; // add spacing for readability
                              }
                         }
                    }
                    reader.Close();
               }
          }
     }
//-------------------------------------------------------------------------------------------
     [SqlFunction(DataAccess = DataAccessKind.Read)]
     public static SqlDateTime LocalizeDT(SqlDateTime dt)
     {
          if (dt.IsNull)
               return new SqlDateTime();

          return new SqlDateTime(dt.Value.ToLocalTime());
     }
//-------------------------------------------------------------------------------------------
     [SqlFunction(DataAccess = DataAccessKind.Read)]
     public static SqlDateTime YearMonth(SqlDateTime dt)
     {
          if (dt.IsNull)
               return new SqlDateTime();

          System.DateTime moment = dt.Value.ToLocalTime();
          return new SqlDateTime(moment.Year, moment.Month, 1); //.ToString("yyyy-M"));
     }
//-------------------------------------------------------------------------------------------
}