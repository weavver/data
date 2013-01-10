using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.DynamicData.ModelProviders;
using System.ComponentModel;

namespace Weavver.Data
{
    public class SecureMetaChildrenColumn : MetaChildrenColumn
    {
        public SecureMetaChildrenColumn(MetaTable table, ColumnProvider columnProvider) :
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
