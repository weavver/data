using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
//--------------------------------------------------------------------------------------------
     [SqlFunction(DataAccess = DataAccessKind.Read)]
     [return: Microsoft.SqlServer.Server.SqlFacet(Precision = 18, Scale = 2)]
     public static SqlDecimal Total_ForLedger(Guid organizationId,
                                              Guid accountId,
                                              string ledgerType,
                                              bool includeCredits,
                                              bool includeDebits,
                                              bool includeReservedFunds,
                                              SqlDateTime startDate,
                                              SqlDateTime endDate,
                                              bool includeItemsOnEndDate)
     {
          string query = @"select isnull(sum(Amount),0) from Accounting_LedgerItems
                           where OrganizationId = @OrganizationId";

          SqlCommand cmd = new SqlCommand(query);
          cmd.Parameters.AddWithValue("@OrganizationId", organizationId);

          if (ledgerType != null)
          {
               cmd.CommandText += " and LedgerType = @LedgerType";
               cmd.Parameters.AddWithValue("@LedgerType", ledgerType);
          }

          if (accountId != Guid.Empty)
          {
               cmd.CommandText += " and AccountId = @AccountId";
               cmd.Parameters.AddWithValue("@AccountId", accountId);
          }

          if (!includeCredits || !includeDebits)
          {
               if (!includeCredits && !includeDebits)
                    throw new Exception("Your total must include credits and/or debits.");
               else if (includeCredits)
                    cmd.CommandText += " and Amount > 0";
               else if (includeDebits)
                    cmd.CommandText += " and Amount < 0";
          }

          if (!includeReservedFunds)
               cmd.CommandText += " and Code != 'Reserve'";

          if (!startDate.IsNull)
          {
               DateTime UtcStartDateTime = DateTime.SpecifyKind(startDate.Value, DateTimeKind.Utc);
               cmd.CommandText += " and PostAt >= @StartDate";
               cmd.Parameters.AddWithValue("@StartDate", UtcStartDateTime);
          }
          if (!endDate.IsNull)
          {
               DateTime UtcEndDateTime = DateTime.SpecifyKind(endDate.Value, DateTimeKind.Utc);
               if (includeItemsOnEndDate)
               {
                    cmd.CommandText += " and PostAt <= @EndDate";
               }
               else
               {
                    cmd.CommandText += " and PostAt < @EndDate";
               }
               cmd.Parameters.AddWithValue("@EndDate", UtcEndDateTime);
          }

          decimal total = 0m;
          using (SqlConnection con = new SqlConnection("context connection=true"))
          {
               try
               {
                    cmd.Connection = con;
                    con.Open();
                    total = (decimal)cmd.ExecuteScalar();
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
          return new SqlDecimal(total);
     }
//-------------------------------------------------------------------------------------------
}