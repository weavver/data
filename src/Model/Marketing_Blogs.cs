     using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Marketing_Blogs.Metadata))]
     [DisplayName("Blogs")]
     [DisplayColumn("PublishAt", "PublishAt", true)]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Marketing_Blogs : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               public object OrganizationId;

               [Display(Name = "Publish Date", Order = 0)]
               public object PublishAt;

               [Display(Order = 1)]
               public object Status;

               [UIHint("Code")]
               [HideColumnIn(PageTemplate.List)]
               public object Body;

               [Display(Name = "Created At")]
               public object CreatedAt;

               [Display(Name = "Updated At")]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;
          }
     }
}