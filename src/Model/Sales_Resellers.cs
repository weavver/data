using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_Resellers.Metadata))]
     [DisplayName("Resellers")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Sales_Resellers : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name = "Client", Order = 1)]
               public object Logistics_Organizations1;

               [Display(Name = "Manager", Order = 2)]
               public object HR_Staff;

               [Display(Name = "Discounts")]
               public object Sales_Discounts;
               //[DisplayFormat(DataFormatString = "{0:C}")]
               //public object Total;
          }
     }
}