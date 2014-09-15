using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Accounting_AccountBalances.Metadata))]
     [DisplayName("Account Balances")]
     [DisplayColumn("AccountName", "AccountName", false)]
     //[SecureTable(TableView.List, "Administrators", "Accountants")]
     //[SecureTable(RowView.Edit, "Administrators", "Accountants")]
     //[SecureTable(RowView.Details, "Administrators", "Accountants")]
     partial class Accounting_AccountBalances// : INavigationActions
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object OrganizationId;

               [ScaffoldColumn(false)]
               public object AccountId;

               [UIHint("Enum")]
               [Display(Name = "Type", Order = 1)]
               [EnumDataType(typeof(LedgerType))]
               [FilterUIHint("Enum")]
               public object LedgerType;

               [Display(Name="Account Name", Order = 2)]
               public object AccountName;
               
               [Display(Order = 25)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Balance;
          }
//-------------------------------------------------------------------------------------------
//          [DynamicDataWebMethod("Ledger", "Accountants")]
//          public DynamicDataWebMethodReturnType Receivables()
//          {
//               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
//               ret.RedirectRequest = true;
//               ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
//               return ret;
//          }
////-------------------------------------------------------------------------------------------
//          public string DetailURL
//          {
//               get
//               {
//                    return "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
//               }
//          }
//-------------------------------------------------------------------------------------------
          public string ListURL
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public string CancelURL
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public List<Web.WeavverMenuItem> GetTableMenu()
          {
               return null;
          }
//-------------------------------------------------------------------------------------------
          public List<Web.WeavverMenuItem> GetItemMenu()
          {
               return null;
          }
//-------------------------------------------------------------------------------------------
     }
}