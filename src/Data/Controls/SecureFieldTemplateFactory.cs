
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Security.Permissions;
using System.Web.Compilation;
using System.Web.Hosting;
using System.Web.UI.WebControls;
using System;
using System.Web.DynamicData;

namespace Weavver.Data
{
    public class SecureFieldTemplateFactory : FieldTemplateFactory
    {
        public override IFieldTemplate CreateFieldTemplate(MetaColumn column, DataBoundControlMode mode, string uiHint)
        {
             if (column.IsReadOnly)// code to fix caching issue
                    mode = DataBoundControlMode.ReadOnly;

               return base.CreateFieldTemplate(column, mode, uiHint);
        }
    }
}