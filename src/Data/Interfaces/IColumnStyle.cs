using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Web.UI.WebControls;

namespace Weavver.Data
{
     public interface IColumnStyle
     {
          void GetColumnStyle(TableCell headerCell, TableCell cell, out string cssNormal, out string cssHover);
     }
}
