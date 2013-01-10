using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Linq.Expressions;
using System.Web.DynamicData;

namespace Weavver.Data
{
     public class ForeignKeyManager
     {
//-------------------------------------------------------------------------------------------
          public static void PopulateListControl(MetaForeignKeyColumn Column,
                                                 DropDownList listControl,
                                                 Guid orgId)
          {
               //var filterAttribute = Column.GetAttribute<FilterForeignKeyAttribute>();
               //if (filterAttribute == null || Session[filterAttribute.SessionVariableName] == null)
               //{
               //     base.PopulateListControl(listControl);
               //     return;
               //}

               var context = Column.Table.CreateContext(); // get context; 
               var foreignKeyTable = Column.ParentTable; // get fkTable 
               var filterColumn = foreignKeyTable.GetColumn("OrganizationId"); // get filter column 
               var value = orgId; //Convert.ChangeType(, filterColumn.TypeCode, System.Globalization.CultureInfo.InvariantCulture); // get value
               var query = foreignKeyTable.GetQuery(context); // Get Column Value query 
               var entityParam = Expression.Parameter(foreignKeyTable.EntityType, foreignKeyTable.Name); // get the table entity to be filtered
               var property = Expression.Property(entityParam, filterColumn.Name); // get the property to be filtered 
               var equalsCall = Expression.Equal(property, Expression.Constant(value)); // get the equal call 
               var whereLambda = Expression.Lambda(equalsCall, entityParam); // get the where lambda 
               var whereCall = Expression.Call(typeof(Queryable), "Where", new Type[] { foreignKeyTable.EntityType }, query.Expression, whereLambda); // get the where call 
               var values = query.Provider.CreateQuery(whereCall);
               foreach (var row in values)
               {
                    listControl.Items.Add(new ListItem()
                    {
                         Text = foreignKeyTable.GetDisplayString(row),
                         Value = foreignKeyTable.GetPrimaryKeyString(row)
                    });
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
