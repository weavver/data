using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace Weavver.Data
{
     public interface IWeavverEntityContainerExtender
     {
          void OnContextCreated(WeavverEntityContainer container);
     }
}