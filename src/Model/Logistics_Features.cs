using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Logistics_Features.Metadata))]
     [DisplayName("Features")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [ScaffoldTable(false)]
     partial class Logistics_Features : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               //[Display(Name="Product", Order = 1)]
               //public object Logistics_Products;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               public object UpdatedAt;

               //[ScaffoldColumn(false)]
               //public object Logistics_Organizations;
          }
//-------------------------------------------------------------------------------------------
     }
//-------------------------------------------------------------------------------------------
     public enum FeatureBillingType
     {
          Monthly,
          OneTime
     }
//-------------------------------------------------------------------------------------------
}