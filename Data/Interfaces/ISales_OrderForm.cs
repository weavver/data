using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

namespace Weavver.Data.Interfaces
{
     public interface ISales_OrderForm
     {
          //bool IsFixedQuantity = false;
          void BeforeAddingToCart(Sales_ShoppingCartItems item);
     }
}