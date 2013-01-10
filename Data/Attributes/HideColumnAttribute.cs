using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
     public class HideColumnInAttribute : Attribute
     {
          public PageTemplate[] PageTemplates { get; private set; }

          public HideColumnInAttribute() { }

          public HideColumnInAttribute(PageTemplate lookupTable)
          {
               PageTemplates = new PageTemplate[] { lookupTable };
          }

          public HideColumnInAttribute(PageTemplate[] lookupTable)
          {
               PageTemplates = lookupTable;
          }
     }
}
