using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     public enum TicketStatus
     {
          Open = 0,
          Closed = 1
     }
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(CustomerService_Tickets.Metadata))]
     [DisplayName("Tickets")]
     [DataAccess(TableView.List, "Administrators", "Customer Service Reps")]
     [DataAccess(RowView.Edit, "Administrators", "Customer Service Reps")]
     [DataAccess(RowView.Details, "Administrators", "Customer Service Reps", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators", "Customer Service Reps", "Guest")]
     partial class CustomerService_Tickets : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [Display(Name = "Client", Order=1)]
               [SecureColumn(ColumnActions.DenyRead, "Guest")]
               public object Logistics_Organizations1;

               [Display(Order = 2)]
               [DefaultValue("New")]
               [SecureColumn(ColumnActions.DenyWrite, "Guest")]
               //[EnumDataType(typeof(TicketStatus))]
               //[UIHint("Enum")]
               [ReadOnly(true)]
               public object Status;

               [Display(Name = "Full Name", Order=3)]
               public object FullName;

               [Display(Name = "Reply To Address", Order = 4)]
               [UIHint("EmailAddress")]
               public object EmailAddress;
               
               [Display(Name = "Call Back Number", Order = 5)]
               public object ContactNumber;

               [Display(Name = "Subject", Order = 20)]
               public object Subject;

               [Display(Name = "Message", Order = 25)]
               [UIHint("Code")]
               [HideColumnIn(PageTemplate.List)]
               public object Message;

               [FilterUIHint("DateTime")]
               [Display(Name = "Created At", Order = 27)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.Insert)]
               [HideColumnIn(PageTemplate.List)]
               public object CreatedAt;

               [FilterUIHint("String")]
               [Display(Name = "Created By", Order = 28)]
               [HideColumnIn(PageTemplate.Insert)]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object System_Users;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Updated At", Order = 29)]
               [HideColumnIn(PageTemplate.Insert)]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [FilterUIHint("String")]
               [Display(Name = "Updated By", Order = 30)]
               [HideColumnIn(PageTemplate.Insert)]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object System_Users1;
          }
     }
}