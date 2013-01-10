using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.ComponentModel;

namespace Weavver.Data
{
    public class SecureMetaForeignKeyColumn : MetaForeignKeyColumn
    {
        public SecureMetaForeignKeyColumn(MetaTable table, ColumnProvider columnProvider) :
            base(table, columnProvider) { }

        protected override void Initialize() { base.Initialize(); }

        public override bool IsReadOnly
        {
            get
            {
                // check if column security is read-only
                // else fall back to Metadata
                if (this.IsSecureColumnReadOnly())
                    return true;
                else
                    return base.IsReadOnly;
            }
        }
    }
}
