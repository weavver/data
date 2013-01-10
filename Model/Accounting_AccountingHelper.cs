using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

using nsoftware.InEBank;

namespace Weavver.Company.Accounting
{
     public class AccountingHelper
     {
          public DataTable transactionRules = new DataTable();
          public DataTable transactions = new DataTable();
          public DataTable taggedTransactions = new DataTable();
     
          public string transactionFolder = @"W:\Projects\Weavver\Main\Servers\web\c\Inetpub\www\Company\Accounting\Transactions\";

          public void CreateTableStructures()
          {
               transactionRules.Columns.Add("Tag");
               transactionRules.Columns.Add("Rule");

               //transactions.PrimaryKey = new DataColumn[] {  };
               transactions.Columns.Add("TXNID", typeof(string));
               transactions.Columns.Add("Date", typeof(DateTime));
               transactions.Columns.Add("Payee");
               transactions.Columns.Add("Amount", typeof(decimal));
               transactions.Columns.Add("Tags");
               transactions.DefaultView.Sort = "Date Desc";

               taggedTransactions.Columns.Add("Date", typeof(DateTime));
               taggedTransactions.Columns.Add("Tag", typeof(string));
               taggedTransactions.Columns.Add("Amount", typeof(decimal));
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This only calculates the in memory table: Accounting.transactions
          /// </summary>
          /// <returns></returns>
          public decimal CalculateTotalCredits()
          {
               decimal baseTotal = 0.0m;
               for (int i = 0; i < transactions.Rows.Count; i++)
               {
                    DataRow row = (DataRow)transactions.Rows[i];
                    decimal amount = (decimal)row[3];
                    if (amount > 0)
                         baseTotal = Decimal.Add(baseTotal, amount);
               }
               return baseTotal;
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This only calculates the in memory table: Accounting.transactions
          /// </summary>
          /// <returns></returns>
          public decimal CalculateTotalDebits()
          {
               decimal baseTotal = 0.0m;
               for (int i = 0; i < transactions.Rows.Count; i++)
               {
                    DataRow row = (DataRow) transactions.Rows[i];
                    decimal amount = (decimal) row[3];
                    if (amount < 0)
                         baseTotal = Decimal.Add(baseTotal, amount);
               }
               return baseTotal;
          }
//-------------------------------------------------------------------------------------------
          //var docs = db.Query("weavver.company.clients", "all").IncludeDocuments().GetResult().Documents<Weavver.Company.Client>();
          //.StartKey(CompanyGuid).EndKey(CompanyGuid)
          //var docs = db.Query("weavver.company.accounting.bills", "by_companyid").IncludeDocuments().GetResult().Documents<Weavver.Company.Accounting.Bill>();
          //List.DataSource = docs;
          //List.DataBind();
          public int MatchAndLog(DateTime posted, string payee, decimal amount)
          {
               int matches = 0;
               foreach (DataRow row in transactionRules.Rows)
               {
                    //Response.Write(row[0] + "," + row[1] + "<br />");
                    if (payee.Trim().StartsWith(row[1].ToString()))
                    {
                         matches += 1;

                         DataRow row2 = taggedTransactions.NewRow();
                         row2[0] = posted; // date
                         row2[1] = row[0]; // tagname
                         row2[2] = amount; // amount
                         taggedTransactions.Rows.Add(row2);
                    }
               }
               if (matches == 0)
               {
                    DataRow row2 = taggedTransactions.NewRow();
                    row2[0] = posted; // date
                    row2[1] = "Other"; // tagname
                    row2[2] = amount; // amount
                    taggedTransactions.Rows.Add(row2);
               }
               return matches;
          }
//-------------------------------------------------------------------------------------------
     }
}