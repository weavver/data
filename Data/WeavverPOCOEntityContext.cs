using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace Weavver.Data
{
     // http://forums.asp.net/t/1770347.aspx/1
     // http://blogs.msdn.com/b/adonet/archive/2009/05/21/poco-in-the-entity-framework-part-1-the-experience.aspx
     // http://msdn.microsoft.com/en-us/library/dd456853.aspx
     // http://forums.asp.net/t/1770347.aspx/1
     public class WeavverPOCOEntityContext : ObjectContext
     {
          public WeavverPOCOEntityContext() : base("name=WeavverPOCOEntities", "WeavverPOCOEntities")
          {
               //_categories = CreateObjectSet<Category>();
               //_products = CreateObjectSet<Product>();
          }

          //public ObjectSet<Category> Categories
          //{
          //     get { return _categories; }
          //}
          //private ObjectSet<Category> _categories;

          //public ObjectSet<Product> Products
          //{
          //     get
          //     {
          //          return _products;
          //     }
          //}
          //private ObjectSet<Product> _products;
     }
}