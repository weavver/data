using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weavver.Web;

namespace Weavver.Data
{
     public interface WeavverMasterPageInterface
     {
          string FormTitle
          {
               set;
          }

          string FormDescription
          {
               set;
          }

          void ActionsMenuAdd(WeavverMenuItem item);
          void ToolBarMenuAdd(WeavverMenuItem item);
          void ViewsMenuAdd(WeavverMenuItem item);

          void SetToolbarVisibility(bool visible);

          bool FixedWidth
          {
               set;
               get;
          }
     }
}