using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Weavver.Data.ExtensionMethods
{
     public static class StringExtensions
     {
          public static int NthIndexOf(this string target, string value, int n)
          {
               Match m = Regex.Match(target, "((" + value + ").*?){" + n + "}");

               if (m.Success)
                    return m.Groups[2].Captures[n - 1].Index;
               else
                    return -1;
          }
     }
}
