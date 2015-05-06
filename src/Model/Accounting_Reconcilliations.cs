using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Data.Entity.Core.Objects;
using System.Runtime.Serialization;

namespace Weavver.Data
{
     [MetadataType(typeof(Accounting_Reconciliations.Metadata))]
     [DisplayName("Reconciliations")]
     [DataAccess(TableView.List, "Administrators", "Accountants")]
     [DataAccess(RowView.Edit, "Administrators", "Accountants")]
     [DataAccess(RowView.Details, "Administrators", "Accountants")]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants")]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants")]
     // [ListDescription("This page provides a list of entered statement summaries and sync states.")]
     [Description("Use the following form to save your statement summaries. This is used to help you reconcile your account.")]
     [DisplayColumn("StartAt", "StartAt", true)]
     partial class Accounting_Reconciliations : IAuditable, IValidator, IColumnStyle // IValidatableObject    
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               //[SecureColumn(ColumnActions.DenyWrite, "Accountants")]
               public object OrganizationId;

               [Display(Order=1)]
               public object Accounting_Accounts;

               [Display(Name = "Starting Date", Order = 2)]
               [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [UIHint("Date")]
               [DataTypeAttribute(DataType.DateTime)]
               public object StartAt;

               [Display(Name = "Ending Date", Order = 3)]
               [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [UIHint("Date")]
               [DataTypeAttribute(DataType.DateTime)]
               public object EndAt;

               [Display(Name = "Starting Balance (=)", Order = 5)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object StartingBalance;

               [Display(Name = "Total Credits (+)", Order = 10)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Credits;
               
               [Display(Name = "Total Debits (-)", Order = 15)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Debits;

               [ScaffoldColumn(false)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object EnteredCredits;

               [ScaffoldColumn(false)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object EnteredDebits;

               [Display(Name = "Ending Balance (=)", Order = 20)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object EndingBalance;

               [FilterUIHint("DateTime")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;
          }

          //** Credit Card balances should be entered inversely. If you have a balance of $450 on your card. That means you owe $450 and then in
          //the Weavver Accounting system you would write that you have a balance of -$450.

          // add + /-/= math signs to make this more user friendly
//-------------------------------------------------------------------------------------------
          public void GetColumnStyle(TableCell headerCell, TableCell cell, out string cssNormal, out string cssHover)
          {
               //Reconciliation item = (Reconciliation)e.Item.DataItem;
               //Account acct = DatabaseHelper.Session.Get<Account>(item.Account);

               string fieldName = ((System.Web.UI.WebControls.DataControlFieldCell)headerCell).ContainingField.HeaderText;

               cssNormal = "";
               cssHover = "";

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var account = (from x in data.Accounting_Accounts
                                   where x.Id == Account
                                   select x).First();

                    string ledgerlink = "<a href=\"~/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}&PostAt_Start={2}&PostAt_End={3}\">{4}</a>";
                    string period = StartAt.ToLocalTime().ToString("MM/dd/yy") + " - " + EndAt.ToLocalTime().ToString("MM/dd/yy");
                    cell.Text = String.Format(ledgerlink, Account.ToString(), account.LedgerType.ToString(), StartAt.ToLocalTime().ToString("MM/dd/yy"), EndAt.ToLocalTime().ToString("MM/dd/yy"), period);
                    
                    string accountType = account.LedgerType;

                    if (fieldName == "Starting Balance (=)")
                    {
                         decimal startBalance = EnteredStartingBalance.Value;
                         if (startBalance == StartingBalance)
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f4d7");
                              cell.ToolTip = "The statement/entered numbers match!";
                         }
                         else
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#fcefef");
                              cell.ToolTip = "Starting Balance: " + String.Format("{0:c}", startBalance) + ", off by " + String.Format("{0:c}", startBalance - StartingBalance);
                         }
                    }
                    if (fieldName == "Ending Balance (=)")
                    {
                         decimal endBalance = EnteredEndingBalance.Value;
                         if (endBalance == EndingBalance)
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f4d7");
                              cell.ToolTip = "The statement/entered numbers match!";
                         }
                         else
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#fcefef");
                              cell.ToolTip = "Ending Balance: " + String.Format("{0:c}", endBalance) + ", off by " + String.Format("{0:c}", endBalance - EndingBalance);
                         }
                    }
                    if (fieldName == "Total Credits (+)")
                    {
                         decimal credits = EnteredCredits.Value;
                         if (credits == Credits.Value)
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f4d7");
                              cell.ToolTip = "The statement/entered numbers match!";
                         }
                         else
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#fcefef");
                              cell.ToolTip = "Entered Credits: " + String.Format("{0:c}", credits) + ", off by " + String.Format("{0:c}", credits - Credits.Value);
                         }
                    }

                    if (fieldName == "Total Debits (-)")
                    {
                         decimal debits = EnteredDebits.Value * -1.0m;
                         if (debits < 0)
                         {
                              cell.ForeColor = System.Drawing.Color.Red;
                         }
                         if (debits == Debits.Value)
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#c9f4d7");
                              cell.ToolTip = "The statement/entered numbers match!";
                         }
                         else
                         {
                              cell.BackColor = System.Drawing.ColorTranslator.FromHtml("#fcefef");
                              cell.ToolTip = "Entered Debits: " + String.Format("{0:c}", debits) + ", off by " + String.Format("{0:c}", debits - Debits.Value);
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("View Ledger Period", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ViewLedgerPeriod()
          {
               string ledgerlink = "~/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}&PostAt_Start={2}&PostAt_End={3}";

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var account = (from x in data.Accounting_Accounts
                                   where x.Id == Account
                                   select x).First();
                    ledgerlink = String.Format(ledgerlink, Account.ToString(),
                                                           account.LedgerType.ToString(),
                                                           StartAt.ToLocalTime().ToString("MM/dd/yy"),
                                                           EndAt.ToLocalTime().ToString("MM/dd/yy"));
               }

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectURL = ledgerlink;
               ret.RedirectRequest = true;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               if (StartingBalance + Credits.Value - Debits.Value == EndingBalance)
               {
                    Valid = true;
                    ErrorMessage = null;
                    //Response.Redirect("Accounting_Reconcilliation/List.aspx?id=" + item.Id.ToString());
               }
               else
               {
                    Valid = false;
                    ErrorMessage = "The credits and debits do not match up with the starting and end balances.";
               }
          }
//-------------------------------------------------------------------------------------------
     }
}