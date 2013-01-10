using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

//namespace Weavver.Data
//{
//     static class EntityDataSourceExtensions
//     {
//          public static TEntity GetItemObject<TEntity>(object dataItem) where TEntity : class
//          {
//               var entity = dataItem as TEntity;
//               if (entity != null)
//               {
//                    return entity;
//               }
//               var td = dataItem as ICustomTypeDescriptor;
//               if (td != null)
//               {
//                    return (TEntity)td.GetPropertyOwner(null);
//               }
//               return null;
//          }
//     }
//}
