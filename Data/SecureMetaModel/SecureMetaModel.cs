using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Collections.Generic;

namespace Weavver.Data
{
     public class SecureMetaModel : MetaModel
     {
          public delegate IEnumerable<MetaColumn> GetVisibleColumns(IEnumerable<MetaColumn> columns);
          private GetVisibleColumns _getVisibleColumns;

          public SecureMetaModel() : base(false) { }

          public SecureMetaModel(GetVisibleColumns getVisibleColumns)
          {
               _getVisibleColumns = getVisibleColumns;
          }

          protected override MetaTable CreateTable(TableProvider provider)
          {
               if (_getVisibleColumns == null)
                    return new SecureMetaTable(this, provider);
               else
                    return new SecureMetaTable(this, provider, _getVisibleColumns);
          }
     }
}
