using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Logistics_Addresses.Metadata))]
     [DataAccess(TableView.List, "Administrators", Width=921, Height=677)]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [DisplayName("Addresses")]
     [ScaffoldTable(false)]
     partial class Logistics_Addresses : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [FilterUIHint("String")]
               [Display(Name = "Line 1")]
               public object Line1;

               [FilterUIHint("String")]
               [Display(Name = "Line 2")]
               public object Line2;

               [FilterUIHint("String")]
               [Display(Name = "City")]
               public object City;

               [FilterUIHint("String")]
               [Display(Name = "State")]
               public object State;

               [FilterUIHint("String")]
               [Display(Name = "Postal Code")]
               public object ZipCode;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [ScaffoldColumn(false)]
               public object Sales_Orders;

               [ScaffoldColumn(false)]
               public object Sales_Orders1;

               [FilterUIHint("DateTime")]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object CreatedAt;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
//-------------------------------------------------------------------------------------------
          public override string ToString()
          {
               string address = "";
               if (!String.IsNullOrEmpty(Line1))
                    address += Line1 + "\r\n";
               if (!String.IsNullOrEmpty(Line2))
                    address += Line2 + "\r\n";
               if (!String.IsNullOrEmpty(City))
                    address += City + ", ";
               if (!String.IsNullOrEmpty(State))
                    address += State + " ";
               if (!String.IsNullOrEmpty(ZipCode))
                    address += ZipCode;
               return address;
          }
//-------------------------------------------------------------------------------------------
     }
}