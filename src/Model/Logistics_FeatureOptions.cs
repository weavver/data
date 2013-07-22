using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Logistics_FeatureOptions.Metadata))]
     [DisplayName("Feature Options")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [ScaffoldTable(false)]
     partial class Logistics_FeatureOptions : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [Display(Order=1)]
               public object Logistics_Features;

               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Cost;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               public object CreatedAt;

               [ReadOnly(true)]
               public object UpdatedAt;
          }
     }
}