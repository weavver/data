using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public interface IValidator
     {
          void Validate(out bool Valid, out string ErrorMessage);
     }
}
