using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
     public class HideIfFiltered : Attribute
     {
          public string FilterName { get; set; }

          public HideIfFiltered()
          {
          }
          public HideIfFiltered(string _filtername)
          {
               FilterName = _filtername;
          }
     }
}
