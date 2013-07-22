using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Legal_Agreements.Metadata))]
     [DisplayName("Agreements")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Legal_Agreements : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object Body;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Created At")]
               [HideColumnIn(PageTemplate.List)]
               public object CreatedAt;

               [ReadOnly(true)]
               [Display(Name="Last Modified")]
               public object UpdatedAt;

               // stylize the output: <div style="line-height: 1.25;></div>
          }
     }
}