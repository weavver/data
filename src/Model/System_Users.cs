using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Security;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(System_Users.Metadata))]
     [DisplayColumn("Username", "Username", false)]
     [DisplayName("Users")]
     [ScaffoldTable(true)]
     [DataAccess(TableView.List, "Administrators")]
     //[DataAccess(TableView.CSV, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class System_Users : IAuditable //, IValidator
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public Guid Id;

               [Display(Name="Email Address")]
               [FilterUIHint("String")]
               [UIHint("EmailAddress")]
               public object EmailAddress;

               [Display(Name = "Username")]
               [FilterUIHint("String")]
               [UIHint("Username")]
               public object Username;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               public object Password;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "User Code")]
               public object UserCode;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Pass Code")]
               public object PassCode;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "First Name")]
               public object FirstName;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Middle Name")]
               public object MiddleName;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Last Name")]
               public object LastName;

               [HideColumnIn(PageTemplate.List)]
               public object Activated;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name="Activation Key")]
               public object ActivationKey;

               [HideColumnIn(PageTemplate.List)]
               public object Locked;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Referred By")]
               public object ReferredBy;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Password Answer")]
               public object PasswordAnswer;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Password Question")]
               public object PasswordQuestion;

               [Display(Name="Last Logged In")]
               [ReadOnly(true)]
               public object LastLoggedIn;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object CreatedBy;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedBy;

               //[HideColumnIn(PageTemplate.List)]
               //public object IT_DownloadLogs;

               //[ScaffoldColumn(false)]
               //public object KnowledgeBases;

               //[ScaffoldColumn(false)]
               //public object KnowledgeBases1;

               //[ScaffoldColumn(false)]
               //public object Accounting_LedgerItems;

               //[ScaffoldColumn(false)]
               //public object Accounting_LedgerItems1;

               [ScaffoldColumn(false)]
               public object CMS_Pages;

               [ScaffoldColumn(false)]
               public object CMS_Pages1;

               [ScaffoldColumn(false)]
               public object Logistics_Products;

               [ScaffoldColumn(false)]
               public object System_URLs;
               
               [ScaffoldColumn(false)]
               public object System_URLs1;
               
               //[ScaffoldColumn(false)]
               //public object Data_AuditTrails;
               
               [ScaffoldColumn(false)]
               public object Communication_EmailAccounts;

               [ScaffoldColumn(false)]
               public object Communication_EmailAccounts1;
               
               [ScaffoldColumn(false)]
               public object Communication_Emails;

               [ScaffoldColumn(false)]
               public object Communication_Emails1;

               [ScaffoldColumn(false)]
               public object Data_Links;

               [ScaffoldColumn(false)]
               public object Data_Links1;

               [ScaffoldColumn(false)]
               public object Sales_ShoppingCartItems;

               [ScaffoldColumn(false)]
               public object Sales_ShoppingCartItems1;

               [ScaffoldColumn(false)]
               public object Logistics_Products1;

               [ScaffoldColumn(false)]
               public object Accounting_RecurringBillables;

               [ScaffoldColumn(false)]
               public object Accounting_RecurringBillables1;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations1;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeys;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeys1;

               [ScaffoldColumn(false)]
               public object Accounting_OFXSettings;

               [ScaffoldColumn(false)]
               public object Accounting_OFXSettings1;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeyActivations;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeyActivations1;

               [ScaffoldColumn(false)]
               public object HR_Tasks;

               [ScaffoldColumn(false)]
               public object HR_Tasks1;

               [ScaffoldColumn(false)]
               public object CustomerService_Tickets;

               [ScaffoldColumn(false)]
               public object CustomerService_Tickets1;

               [ScaffoldColumn(false)]
               public object Sales_Orders;

               [ScaffoldColumn(false)]
               public object Sales_Orders1;
          }
//-------------------------------------------------------------------------------------------
          public string FullName
          {
               get
               {
                    string name = FirstName + " " + LastName;
                    name = name.Trim();
                    if (String.IsNullOrEmpty(name))
                         name = Username;
                    return name;
               }
          }
//-------------------------------------------------------------------------------------------
          public override string ToString()
          {
               return FullName;
          }
//-------------------------------------------------------------------------------------------
          public void Purge()
          {
               throw new Exception("Purge not implemented");
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               MembershipUser memUser = Membership.GetUser(Username);
               if (memUser != null)
               {
                    ErrorMessage = "Duplicate username, please choose another username.";
                    Valid = false;
               }
               else
               {
                    Valid = true;
                    ErrorMessage = null;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}