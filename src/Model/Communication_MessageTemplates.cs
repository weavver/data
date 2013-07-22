using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Communication_MessageTemplates.Metadata))]
     [DisplayName("Message Templates")]
     [DisplayColumn("Name", "Name", false)]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Communication_MessageTemplates : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               [HideColumnIn(PageTemplate.List)]
               public object OrganizationId;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object Body;
          }
     }
}