﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public interface IOrderEvents
     {
//-------------------------------------------------------------------------------------------
          void Provision(Sales_Orders order, Sales_ShoppingCartItems item);
//-------------------------------------------------------------------------------------------
     }
}
