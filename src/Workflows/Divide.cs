using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weavver.Workflows
{
     public sealed class Divide : CodeActivity<int>
     {
         public InArgument<int> Dividend { get; set; }
         public InArgument<int> Divisor { get; set; }
         public OutArgument<int> Remainder { get; set; }

         protected override int Execute(CodeActivityContext context)
         {
             int quotient = Dividend.Get(context) / Divisor.Get(context);
             int remainder = Dividend.Get(context) % Divisor.Get(context);

             Remainder.Set(context, remainder);

             return quotient;
         }
     }
}
