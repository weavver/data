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
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Showcase, "Administrators", "Guest")]
     [SecureTable(TableActions.StoreItem, "Administrators", "Guest")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
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