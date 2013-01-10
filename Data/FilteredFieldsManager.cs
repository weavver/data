using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Web.DynamicData;
using System.Web.UI;

namespace Weavver.Data
{
     public class FilteredFieldsManager : IAutoFieldGenerator
     {
          protected MetaTable _table;
          protected PageTemplate _currentPage;

          public List<DynamicField> _selectedColumns = new List<DynamicField>();
//-------------------------------------------------------------------------------------------
          public FilteredFieldsManager(MetaTable table, PageTemplate currentPage)
          {
               _table = table;
               _currentPage = currentPage;

               foreach (var column in _table.Columns)
               {
                    // carry on the loop at the next column  
                    // if scaffold table is set to false or DenyRead
                    if (!column.Scaffold ||
                         column.IsLongString ||
                         column.ColumnIsInPage(_currentPage))
                         continue;

                    var f = new DynamicField();

                    f.DataField = column.Name;
                    _selectedColumns.Add(f);
               }
          }
//-------------------------------------------------------------------------------------------
          public List<DynamicField> SelectedColumns
          {
               get
               {
                    return _selectedColumns;
               }
          }
//-------------------------------------------------------------------------------------------
          public ICollection GenerateFields(Control control)
          {
               return _selectedColumns;
          }
//-------------------------------------------------------------------------------------------
     }
}
