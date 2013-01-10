using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public interface IRowStyle
     {
          void GetRowStyle(out string cssNormal, out string cssHover);
     }
}
