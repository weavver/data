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
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators", "Guest")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
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