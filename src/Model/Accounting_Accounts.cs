using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Weavver.Web;
using Weavver.Data.Interfaces;
using Weavver.Security;

namespace Weavver.Data
{
     [MetadataType(typeof(Accounting_Accounts.Metadata))]
     [DisplayName("Financial Accounts")]
     [DisplayColumn("Name", "Name", false)]
     [DataAccess(TableView.List, "Administrators", "Accountants", Width=875, Height=600)]
     [DataAccess(RowView.Edit, "Administrators", "Accountants", Width = 750, Height = 560)]
     [DataAccess(RowView.Details, "Administrators", "Accountants", Width = 750, Height = 560)]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants")]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants", Width = 750, Height = 560)]
     //"An overview of your bank, reserve, and credit card accounts."
     //"Use an account to track your checking and savings accounts."
     [CSS("width: 475px; height: 872;")]
     partial class Accounting_Accounts : IAuditable, INavigationActions
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               //[ScaffoldColumn(false)]
               //public object ExternalId;

               //[Display(Order = 1)]
               //public object Accounting_Accounts;

               [UIHint("Enum")]
               [FilterUIHint("Enum")]
               [Display(Name = "Type", Order = 5)]
               [EnumDataType(typeof(LedgerType))]
               public object LedgerType;

               [Display(Order = 10)]
               [FilterUIHint("String")]
               //[SecureColumnAttribute(ColumnActions.DenyWrite, "Administrators")]
               public object Name;

               [Display(Name="Account Number", Order = 15)]
               [UIHint("AccountNumber")]
               public object AccountNumber;


               [Display(Order = 20)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Balance;

               [Display(Name = "Projected Balance", Order = 25)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object AvailableBalance;

               // add these two columns
               //e.Item.Cells[2].Text = String.Format("{0,10:C}", ofxBank.LedgerBalance);
               //e.Item.Cells[3].Text = String.Format("{0,10:C}", ofxBank.AvailableBalance);

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name="Updated At")]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object Organization;

               [ScaffoldColumn(false)]
               public object Accounting_Reconciliations;

               [ScaffoldColumn(false)]
               public object Accounting_Checks;

               [Display(Name = "Created By")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object Logistics_Organizations;

               [ScaffoldColumn(false)]
               public object Accounting_Accounts1;

               [Display(Name = "Updated By")]
               [ReadOnly(true)]
               public object Accounting_Accounts2;

               [ScaffoldColumn(false)]
               public object Accounting_OFXSettings;
          }
//-------------------------------------------------------------------------------------------
          public Accounting_OFXSettings GetOFXSettings()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Accounting_OFXSettings settings = (from x in data.Accounting_OFXSettings
                                                       where x.AccountId == Id
                                                       select x).FirstOrDefault();
                    if (settings != null)
                    {
                         data.Accounting_OFXSettings.Detach(settings);
                    }
                    return settings;
               }
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Ledger", "Accountants")]
          public DynamicDataWebMethodReturnType ViewLedger()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectWidth = 1192;
               ret.RedirectHeight = 492;
               ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?AccountId=" + Id.ToString() + "&LedgerType=" + LedgerType.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("OFX Settings", "Accountants")]
          public DynamicDataWebMethodReturnType OFXSettings()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
                    ret.RedirectRequest = true;
                    ret.RedirectWidth = 800;
                    ret.RedirectHeight = 500;
                    var settings = GetOFXSettings();
                    if (settings == null)
                    {
                         ret.RedirectURL = "~/Accounting_OFXSettings/Details.aspx?AccountId=" + Id.ToString();
                    }
                    else
                    {
                         ret.RedirectURL = "~/Accounting_OFXSettings/Details.aspx?Id=" + settings.Id.ToString();
                    }
                    return ret;
               }
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Import Data", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ImportData()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectWidth = 800;
               ret.RedirectHeight = 500;
               ret.RedirectURL = "~/Imports/Accounting_LedgerItems?AccountId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Export Data to IIF", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ExportIIF()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "~/Exports/Accounting_IIF?AccountId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          //public List<Web.WeavverMenuItem> GetItemMenu(WeavverMembershipUser securityUser)
          //{
          //     List<Web.WeavverMenuItem> items = new List<WeavverMenuItem>();
               
          //     WeavverMenuItem exportIIF = new WeavverMenuItem();
          //     exportIIF.Name = "Export IIF";
          //     exportIIF.Link = "#";

          //     return items;
          //}
//-------------------------------------------------------------------------------------------
          public static List<WeavverMenuItem> GetTableMenu()
          {
               List<WeavverMenuItem> items = new List<WeavverMenuItem>();

               WeavverMenuItem item = new WeavverMenuItem();
               item.Name = "Quick Transfer";
               item.Link = "control://~/DynamicData/QuickAdd/Accounting_Accounts_QuickTransfer.ascx";
               items.Add(item);

               return items;
          }
//-------------------------------------------------------------------------------------------
          public string DetailURL
          {
               get { return null; }
          }
//-------------------------------------------------------------------------------------------
          public string ListURL
          {
               get { return null; }
          }
//-------------------------------------------------------------------------------------------
          public string CancelURL
          {
               get { return null; }
          }
//-------------------------------------------------------------------------------------------
          public List<WeavverMenuItem> GetItemMenu()
          {
               return null;
          }
//-------------------------------------------------------------------------------------------
     }
}