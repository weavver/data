using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Core.Objects;

namespace Weavver.Data
{
     public interface IWeavverEntityContainerExtender
     {
          void OnContextCreated(WeavverEntityContainer container);
     }
}