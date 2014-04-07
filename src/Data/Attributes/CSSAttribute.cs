using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
     public class CSSAttribute : Attribute
     {
          public string _CSS;

          public CSSAttribute() { }

          public CSSAttribute(string CSS)
          {
               _CSS = CSS;
          }
     }
}
