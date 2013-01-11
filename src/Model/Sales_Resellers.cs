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
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
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