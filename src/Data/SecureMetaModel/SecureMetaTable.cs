using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Web.UI.WebControls;

namespace Weavver.Data
{
    public class SecureMetaTable : MetaTable
    {
          private SecureMetaModel.GetVisibleColumns _getVisibleColumns;


          public SecureMetaTable(MetaModel metaModel, TableProvider tableProvider) :
               base(metaModel, tableProvider) { }


          public SecureMetaTable(MetaModel metaModel, TableProvider tableProvider, SecureMetaModel.GetVisibleColumns getVisibleColumns) :
               base(metaModel, tableProvider)
          {
               _getVisibleColumns = getVisibleColumns;
          }

        protected override void Initialize() { base.Initialize(); }

        protected override MetaColumn CreateColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaColumn(this, columnProvider);
        }

        protected override MetaChildrenColumn CreateChildrenColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaChildrenColumn(this, columnProvider);
        }

        protected override MetaForeignKeyColumn CreateForeignKeyColumn(ColumnProvider columnProvider)
        {
            return new SecureMetaForeignKeyColumn(this, columnProvider);
        }

        public override IEnumerable<MetaColumn> GetScaffoldColumns(DataBoundControlMode mode, ContainerType containerType)
        {
             if (_getVisibleColumns == null)
             {
                  var visibleColumn = base.GetScaffoldColumns(mode, containerType);
                  var secureColumns = from column in visibleColumn
                                      where column.ColumnIsVisible()
                                      select column;
                  return secureColumns;
             }
             else
             {
                  return _getVisibleColumns(base.GetScaffoldColumns(mode, containerType));
             }
        }
    }
}