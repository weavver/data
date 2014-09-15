using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     public enum OrganizationTypes
     {
          SoleProprietorship,
          SCorp,
          LLC,
          NonProfit,
          Family,
          Personal
     }
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Logistics_Organizations.Metadata))]
     [DisplayColumn("Name", "Name", false)]
     [DisplayName("Organizations")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", Width=400)]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     //[AutoLinkToView("OrganizationPayables"]
     //"Organizations are used to create profiles for your personal, work, family, and/or other data."
     partial class Logistics_Organizations : IAuditable
     {
          // Master.AddAttachmentLink("Users", "~/System_Users/Edit.aspx?OrganizationId=" + item.OrganizationId.ToString(), "");
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name="Type", Order = 1)]
               [UIHint("Enum")]
               [EnumDataType(typeof(OrganizationTypes))]
               public object OrganizationType;

               [Display(GroupName = "Test", Order = 30)]
               [FilterUIHint("String")]
               public object Name;

               [Display(Order = 40)]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object Bio;

               [Display(Order = 50)]
               [HideColumnIn(PageTemplate.List)]
               public object Founded;

               [Display(Name = "Vanity URL", Order=60)]
               public object VanityURL;

               //[Display(Name = "Billing Address", Order = 70)]
               //[HideColumnIn(PageTemplate.List)]
               //public object BillingAddressFK;

               [ColumnGroup("Financials")]
               [Display(Order = 35)]
               [HideColumnIn(PageTemplate.List)]
               public object EIN;
               // Tax information is optional and only required if you are signing up as a vendor.

               [ColumnGroup("Financials")]
               [Display(Name = "Receivable Balance", Order = 75)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object ReceivableBalance;

               [ColumnGroup("Financials")]
               [Display(Name = "Payable Balance", Order = 80)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object PayableBalance;

               [ColumnGroup("Merchant Account")]
               [Display(Name = "Authorize.Net Login Id", Order = 90)]
               [HideColumnIn(PageTemplate.List)]
               public object AuthorizeNet_LoginId;

               [ColumnGroup("Merchant Account")]
               [Display(Name = "Authorize.Net Transaction Key", Order = 91)]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               public object AuthorizeNet_TransactionKey;

               [ColumnGroup("Merchant Account")]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               [Display(Name = "Authorize.Net Hash", Order = 92)]
               public object AuthorizeNet_Hash;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Active Directory Domain", Order = 93)]
               public object ActiveDirectory_Domain;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Active Directory Server", Order = 94)]
               [ScaffoldColumn(true)]
               public object ActiveDirectory_Server;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Active Directory Password", Order = 95)]
               [UIHint("Password")]
               public object ActiveDirectory_Password;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Smtp Server", Order = 96)]
               public object SmtpServer;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Smtp Port", Order = 97)]
               public object SmtpPort;

               [ColumnGroup("System Settings")]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               [Display(Name = "FreeSwitch Server", Order = 98)]
               public object FreeSwitch_Server;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name="Created At")]
               public object CreatedAt;

               //[FilterUIHint("Guid")]
               [ReadOnly(true)]
               public object CreatedBy;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;

               [ReadOnly(true)]
               public object UpdatedBy { get; set; }

               [ScaffoldColumn(false)]
               public object Accounting_Accounts;

               [ScaffoldColumn(false)]
               public object Accounting_CreditCards;

               [ScaffoldColumn(false)]
               public object HR_Jobs;

               [ScaffoldColumn(false)]
               public object HR_TimeLogs;

               [ScaffoldColumn(false)]
               public object Sales_Resellers1;

               [ScaffoldColumn(false)]
               public object Accounting_LedgerItems;

               [ScaffoldColumn(false)]
               public object Marketing_Blogs;

               //[ScaffoldColumn(false)]
               //public object Logistics_Organizations1;

               //[ScaffoldColumn(false)]
               //public object Logistics_Organizations2;

               [ScaffoldColumn(false)]
               public object Accounting_Checks;

               [ScaffoldColumn(false)]
               public object Accounting_Checks1;

               [ScaffoldColumn(false)]
               public object Logistics_Products;

               [ScaffoldColumn(false)]
               public object HR_Staff;

               [ScaffoldColumn(false)]
               public object Sales_Orders;

               [ScaffoldColumn(false)]
               public object Accounting_RecurringBillables;

               [ScaffoldColumn(false)]
               public object Accounting_RecurringBillables1;

               [ScaffoldColumn(false)]
               public object Accounting_RecurringBillables2;

               //[ScaffoldColumn(false)]
               //public object Accounting_Accounts_1;

               [ReadOnly(true)]
               [Display(Name = "Created By")]
               public object System_Users;

               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name="Updated By")]
               public object System_Users1;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeys;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeys1;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeyActivations;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Receivables", "Accountants")]
          public DynamicDataWebMethodReturnType Receivables()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?LedgerType=Receivable&AccountId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Payables", "Accountants")]
          public DynamicDataWebMethodReturnType Payables()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?LedgerType=Payable&AccountId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}