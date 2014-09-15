using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_Leads.Metadata))]
     [DisplayName("Inquiries")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators", "Guest")]
     partial class Sales_Leads : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               //[Display(Name = "Organization", Order = 0)]
               //[ReadOnly(true)]
               //[SecureColumn(ColumnActions.DenyRead, "Guest")]
               //public object Logistics_Organizations;

               [Display(Name = "Source", Order=1)]
               public object Source;

               [Display(Name = "First Name", Order = 2)]
               public object FirstName;

               [Display(Name = "Last Name", Order = 3)]
               public object LastName;

               [Display(Name = "Email Address", Order = 4)]
               public object EmailAddress;

               [Display(Name = "Contact Number", Order = 5)]
               public object ContactNumber;

               [Display(Name = "Would you to be contacted?", Order = 6)]
               [HideColumnIn(PageTemplate.List)]
               public object ContactRequested;

               [Display(Name = "Organization Size", Order = 20)]
               public object OrganizationSize;

               [HideColumnIn(PageTemplate.List)]
               public object Website;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Message")]
               [UIHint("Code")]
               public object Notes;

               [Display(Name = "Where did you hear about us?")]
               [HideColumnIn(PageTemplate.List)]
               public object ReferredBy;

               [ReadOnly(true)]
               [Display(Name = "Created At")]
               [HideColumnIn(PageTemplate.Insert)]
               public object CreatedAt;

               [ScaffoldColumn(false)]
               public object CreatedBy;

               [ScaffoldColumn(false)]
               [ReadOnly(true)]
               [Display(Name = "Updated At")]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object UpdatedBy;
          }
//-------------------------------------------------------------------------------------------
          //[DynamicDataWebMethod("Call Lead", "Administrators")]
          //public DynamicDataWebMethodReturnType CallLead()
          //{
          //     // initialize callback to lead's ph #
          //     // implement code
          //     return null;
          //}
//-------------------------------------------------------------------------------------------
     }
}