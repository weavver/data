using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Logistics_Projects.Metadata))]
     [DisplayColumn("Name", "Name", false)]
     [DisplayName("Projects")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(TableView.Showcase, "Administrators", "Guest")]
     [DataAccess(RowView.StoreItem, "Administrators", "Guest")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     partial class Logistics_Projects : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(GroupName = "Test", Order = 1)]
               [FilterUIHint("String")]
               public object Name;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object CreatedAt;

               [SecureColumn(ColumnActions.DenyWrite)]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
     }
}