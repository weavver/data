using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_Discounts.Metadata))]
     [DisplayName("Special Offers")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Sales_Discounts : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name="Reseller", Order=1)]
               public object Sales_Resellers;

               public object Scope;

               public object Code;
               public object AmountOffRetail;
               public object PercentOffRetail;
               public object ExpiresAt;
               public object CreatedAt;
               public object UpdatedAt;

          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Returns the amount to take off the total shopping cart price.
          /// </summary>
          /// <returns></returns>
          //public decimal CaclulateDiscount(Accounting_ShoppingCart cart)
          //{
          //     return cart.Total * DiscountPercent;
          //     //foreach (ShoppingCartItem item in cart.Items)
          //     //{
          //     //}
          //}
//-------------------------------------------------------------------------------------------
     }
}