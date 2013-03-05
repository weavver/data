using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     public enum LedgerType :  byte
     {
          Payable = 0,
          Receivable = 1,
          Checking = 2,
          Savings = 3,
          CreditCard = 4,
          CreditLine = 5,
          MoneyMarket = 6,
          Holding = 7
     }
//-------------------------------------------------------------------------------------------
     public enum CodeType : byte
     {
          Deposit = 0,
          Investment = 1,
          Gift = 2,
          Payment = 3,
          Purchase = 4,
          Reimbursement = 5,
          Refund = 6,
          Sale = 7,
          Withdrawal = 8,
          Fee = 9,
          Interest = 10,
          Other = 11,
          Reserve = 12,
          Loan = 13,
          Comission = 14,
          Royalty = 15
     }
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Accounting_LedgerItems.Metadata))]
     [DisplayName("Ledger Items")]
     [SecureTable(TableActions.List, "Administrators", "Accountants")]
     [SecureTable(TableActions.ListDetails, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators", "Accountants")]
     [SecureTable(TableActions.Details, "Administrators", "Accountants")]
     [SecureTable(TableActions.Delete, "Administrators", "Accountants")]
     [SecureTable(TableActions.Insert, "Administrators", "Accountants")]
     [DisplayColumn("Memo", "PostAt", true)]
     public partial class Accounting_LedgerItems : IAuditable, IRowStyle, INavigationActions, IValidator
     {
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(true)]
               [UIHint("Accounting_LedgerItems_TransactionId")]
               [Display(Name = "TXNID", Order = -20)]
               [HideIfFiltered()]
               public object TransactionId;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "External Id", Order = -15)]
               public object ExternalId;

               //[ScaffoldColumn(false)]
               //public object OrganizationId;

               //[ScaffoldColumn(true)]
               [Display(Name = "Account Id", Order = -5)]
               public object AccountId;

               [Display(Name = "Posted", Order = -5)]
               //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [UIHint("Date")]
               [FilterUIHint("DateRange")]
               public object PostAt;

               [ScaffoldColumn(true)]
               [Display(Name = "Account Name", Order = 0)]
               [ReadOnly(true)]
               [HideIfFiltered("AccountId")]
               public object AccountName;

               [Display(Name = "Ledger", Order = 1)]
               [UIHint("Enum")]
               [EnumDataType(typeof(LedgerType))]
               [FilterUIHint("Enum")]
               [ReadOnly(true)]
               [HideIfFiltered()]
               public object LedgerType;

               [EnumDataType(typeof(CodeType))]
               [UIHint("Enum")]
               [FilterUIHint("Enum")]
               public object Code;

               [UIHint("MultilineText")]
               [FilterUIHint("String")]
               public object Memo;

               [DisplayFormat(DataFormatString = "{0:C}")]
               [FilterUIHint("Range")]
               public object Amount;

               [FilterUIHint("DateTime")]
               [UIHint("Date")]
               [Display(Name = "Entered At")]
               [HideColumnIn(PageTemplate.List)]
               //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [ReadOnly(true)]
               public object CreatedAt;

               [Display(Name = "Entered By")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [HideColumnIn(PageTemplate.List)]
               public object CreatedBy;

               [FilterUIHint("DateTime")]
               //[UIHint("Date")]
               [Display(Name = "Updated At")]
               //[DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [ReadOnly(true)]
               //[HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [Display(Name = "Updated By")]
               [ReadOnly(true)]
               //[HideColumnIn(PageTemplate.List)]
               public object System_Users1;

               // add filter:
               //EntryTypeFilter.DataSource = Enum.GetNames(typeof(EntryType));
               //EntryTypeFilter.DataBind();
               //EntryTypeFilter.Items.Insert(0, "All");
          }
//-------------------------------------------------------------------------------------------
          public void GetRowStyle(out string cssRowStyle, out string cssHover)
          {
               if (Amount > 0)
               {
                    cssRowStyle = "CreditRowStyle";
               }
               else if (Amount < 0)
               {
                    cssRowStyle = "DebitRowStyle";
               }
               else
               {
                    cssRowStyle = "CreditRowStyle";
               }

               cssHover = "LedgerItemHoverRowStyle";
          }
//-------------------------------------------------------------------------------------------
          public void GenerateMenu(WeavverMasterPageInterface masterPage)
          {
               //LedgerItemPanel.Visible = (LoggedInUser.OrganizationId == org1.OrganizationId);
               string accountName = "";
               //if (acct == null)
               //{
               //     WeavverMenuItem wMakePayment = new WeavverMenuItem("Make Payment", "~/company/accounting/payment");
               //     Master.ToolBarMenuAdd(wMakePayment);
               //     LedgerItemPanel.Visible = false;
               //}
               //else
               //{
               //     WeavverMenuItem wAddFunds = new WeavverMenuItem("Add Funds", "~/company/accounting/funding");
               //     Master.ToolBarMenuAdd(wAddFunds);
               //}
               //accountName = (Request["accounttype"] == "WebOrder") ? "Web Order Ledger" : Accounting.GetAccountName(LoggedInUser.OrganizationId, accountId);
          }
//-------------------------------------------------------------------------------------------
          //[DynamicDataWebMethod(DynamicMethodScope.Table, "Add Ledger Item", "Accountants")]
          //public static DynamicDataWebMethodReturnType AddLedgerItem()
          //{
          //     var context = System.Web.HttpContext.Current;
          //     var acctId = context.Request["AccountId"];
          //     var ledgType = context.Request["LedgerType"];

          //     DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
          //     ret.RedirectRequest = true;
          //     ret.RedirectURL = "~/Accounting_LedgerItems/Insert.aspx?AccountId=" + acctId + "&LedgerType=" + ledgType;
          //     return ret;
          //}
//-------------------------------------------------------------------------------------------
          public string DetailURL
          {
               get
               {
                    return null;
               }
          }
//-------------------------------------------------------------------------------------------
          public string ListURL
          {
               get
               {
                    return "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
               }
          }
//-------------------------------------------------------------------------------------------
          public string CancelURL
          {
               get
               {
                    return "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
               }
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               if (String.IsNullOrEmpty(ExternalId))
                    ExternalId = Id.ToString();

               ErrorMessage = null;
               Valid = false;
               CodeType codeVal = (CodeType) Enum.Parse(typeof(CodeType), Code);
               switch (codeVal)
               {
                    //CREDITS
                    case CodeType.Comission:
                    case CodeType.Payment:
                    case CodeType.Royalty:
                    case CodeType.Deposit:
                         if (Amount.Value >= 0)
                         {
                              Valid = true;
                         }
                         else
                         {
                              Valid = false;
                              ErrorMessage = "Amount should be a positive number (CREDIT).";
                         }
                         break;

                    // DEBITS
                    case CodeType.Fee:
                    case CodeType.Sale:
                    case CodeType.Withdrawal:
                    case CodeType.Purchase:
                         if (Amount <= 0)
                         {
                              Valid = true;
                         }
                         else
                         {
                              Valid = false;
                              ErrorMessage = "Amount should be a negative number (DEBIT).";
                         }
                         break;

                    //CREDIT OR DEBIT
                    case CodeType.Reserve:
                         Valid = true;
                         break;

                    default:
                         break;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
