using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     public enum EmailAccountType
     {
          POP,
          POPS
     }

     [MetadataType(typeof(Communication_EmailAccounts.Metadata))]
     [DisplayName("Email Accounts")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
     partial class Communication_EmailAccounts : IAuditable
     {
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               [HideColumnIn(PageTemplate.List)]
               public object OrganizationId;

               [UIHint("Enum")]
               [EnumDataType(typeof(EmailAccountType))]
               public object Type;

               [UIHint("Password")]
               [HideColumnIn(PageTemplate.List)]
               public object Password;

               [ReadOnly(true)]
               [Display(Name = "Last Import")]
               public object LastImport;

               [ReadOnly(true)]
               [Display(Name = "Last Import Attempt")]
               public object LastImportAttempt;

               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [ReadOnly(true)]
               [Display(Name = "Updated At")]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name="Created By")]
               public object System_Users;

               [ReadOnly(true)]
               [Display(Name = "Updated By")]
               public object System_Users1;
          }
//-------------------------------------------------------------------------------------------
     }
}