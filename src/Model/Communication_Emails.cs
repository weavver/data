using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Communication_Emails.Metadata))]
     [DisplayName("Emails")]
     [DisplayColumn("Subject", "Subject", false)]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Communication_Emails : IAuditable, IValidator
     {
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               [HideColumnIn(PageTemplate.List)]
               public object OrganizationId;

               [Display(Order=1)]
               [UIHint("EmailAddress")]
               public object From;

               [Display(Order = 2)]
               [UIHint("EmailAddress")]
               public object To;

               [Display(Order = 3)]
               public object Subject;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               [Display(Name="Body")]
               public object HTMLBody;

               [ScaffoldColumn(false)]
               public object Raw;

               [ScaffoldColumn(false)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object CreatedAt;

               [ScaffoldColumn(false)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name = "Created By")]
               public object System_Users;

               [ReadOnly(true)]
               [Display(Name = "Updated By")]
               public object System_Users1;
         }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               //throw new NotImplementedException();
               Valid = true;
               ErrorMessage = null;
          }
//-------------------------------------------------------------------------------------------
     }
}