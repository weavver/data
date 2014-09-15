using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_ShoppingCarts.Metadata))]
     [DisplayName("Shopping Carts")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [Serializable]
     public class Sales_ShoppingCarts
     {
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               public object OrganizationId;
          }
//-------------------------------------------------------------------------------------------
          public bool RequiresOrganizationId
          {
               get
               {
                    foreach (Sales_ShoppingCartItems item in Items)
                    {
                         if (item.RequiresOrganizationId)
                              return true;
                    }
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          public decimal DepositTotal
          {
               get
               {
                    decimal total = 0;
                    foreach (Sales_ShoppingCartItems item in Items)
                    {
                         total += item.Deposit * item.Quantity;
                    }
                    return total;
               }
          }
//-------------------------------------------------------------------------------------------
          public decimal SetUpTotal
          {
               get
               {
                    decimal total = 0;
                    foreach (Sales_ShoppingCartItems item in Items)
                    {
                         total += item.SetUp * item.Quantity;
                    }
                    return total;
               }
          }
//-------------------------------------------------------------------------------------------
          public decimal MonthlyTotal
          {
               get
               {
                    decimal total = 0;
                    foreach (Sales_ShoppingCartItems item in Items)
                    {
                         total += item.Monthly * item.Quantity;
                    }
                    return total;
               }
          }
//-------------------------------------------------------------------------------------------
          public decimal Total
          {
               get
               {
                    decimal total = 0;
                    foreach (Sales_ShoppingCartItems item in Items)
                    {
                         if (item.Total.HasValue)
                              total += item.Total.Value;
                    }
                    return total;
               }
          }
//-------------------------------------------------------------------------------------------
          public List<Sales_ShoppingCartItems> Items
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         string sessId = HttpContext.Current.Session.SessionID;
                         var shoppingCartItems = from items in data.Sales_ShoppingCartItems
                                                 where items.SessionId == sessId
                                                 select items;

                         List<Sales_ShoppingCartItems> _items = shoppingCartItems.ToList<Sales_ShoppingCartItems>();
                         _items.ForEach(x => data.Entry(x).State = System.Data.Entity.EntityState.Detached);
                         return _items;
                    }
               }
               // &&items.OrganizationId == SelectedOrganization.Id
          }
//-------------------------------------------------------------------------------------------
          public override string ToString()
          {
               decimal setup = SetUpTotal;
               decimal deposit = DepositTotal;
               decimal monthly = MonthlyTotal;
               decimal Paid = 0m;
               decimal Balance = Total;
               string order = "";
               foreach (Sales_ShoppingCartItems item in Items)
               {
                    order += item.Name + ", Qty: " + item.Quantity.ToString() + ", ";
                    if (monthly > 0)
                         order += "Monthly: " + monthly.ToString("C") + ", ";
                    order += "Subtotal: " + item.Total.Value.ToString("C") + "\r\n";
               }
               //preload to save retrieval cycles
               if (setup > 0)
                    order += "\r\nSet Up: " + setup.ToString("C");
               if (deposit > 0)
                    order += "\r\nDeposit: " + deposit.ToString("C");
               if (monthly > 0)
                    order += "\r\nMonthly: " + monthly.ToString("C");
               order += "\r\nDue: " + Total.ToString("C");
               order += "\r\nPaid: " + Paid.ToString("C");
               order += "\r\nBalance: " + Balance.ToString("C");
               return order;
          }
//-------------------------------------------------------------------------------------------
     }
}