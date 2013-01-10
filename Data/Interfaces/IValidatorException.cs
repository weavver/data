using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public class IValidatorException : Exception
     {
          public IValidatorException(string message) : base(message)
          {
          }
     }
}
