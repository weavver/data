using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class UserDefinedFunctions
{
//-------------------------------------------------------------------------------------------
     [SqlFunction(DataAccess = DataAccessKind.Read)]
     public static SqlInt32 Sales_LicenseKeys_Activations(SqlGuid licenseKeyId)
     {
          string sql = "select isnull(count(*),0) from Sales_LicenseKeyActivations where LicenseKeyId=@Id";
          SqlCommand cmd = new SqlCommand(sql);
          cmd.Parameters.AddWithValue("@Id", licenseKeyId);

          int count = 0;
          using (SqlConnection con = new SqlConnection("context connection=true"))
          {
               try
               {
                    cmd.Connection = con;
                    con.Open();
                    count = (int)cmd.ExecuteScalar();
               }
               catch (Exception ex)
               {
                    throw ex;
               }
               finally
               {
                    if (con != null)
                         con.Close();
               }
          }
          return new SqlInt32(count);
     }
//-------------------------------------------------------------------------------------------
}