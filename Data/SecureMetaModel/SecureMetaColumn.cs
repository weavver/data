using System;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
    public class SecureMetaColumn : MetaColumn
    {
        public SecureMetaColumn(MetaTable table, ColumnProvider columnProvider) :
            base(table, columnProvider) { }

        protected override void Initialize() { base.Initialize(); }

        public override bool IsReadOnly
        {
            get
            {
                if (this.IsSecureColumnReadOnly())
                    return true;
                else
                    return base.IsReadOnly;
            }
        }
    }
}
