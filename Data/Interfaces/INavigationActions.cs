using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public interface INavigationActions
     {
          string DetailURL
          {
               get;
          }

          string ListURL
          {
               get;
          }

          string CancelURL
          {
               get;
          }
     }
}
