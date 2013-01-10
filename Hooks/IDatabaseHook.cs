using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Hooks
{
     interface IDatabaseHook
     {
          void OnSave();
     }
}
