using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
     public class FilterForeignKeyAttribute : Attribute
     {
          /// <summary>
          /// Gets or sets the name of the filter column.
          /// </summary>
          /// <value>The name of the filter column.</value>
          public String FilterColumnName { get; set; }

          /// <summary>
          /// Gets or sets the name of the session variable.
          /// </summary>
          /// <value>The name of the session variable.</value>
          public String SessionVariableName { get; set; }

          public FilterForeignKeyAttribute(String filterColumnName, String sessionVariableName)
          {
               FilterColumnName = filterColumnName;
               SessionVariableName = sessionVariableName;
          }
     }
}
