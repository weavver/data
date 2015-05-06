using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     partial class Accounting_RecurringBillables : ICRON
     {
//-------------------------------------------------------------------------------------------
          public void RunCronTasks(Utilities.CommandLineArguments args)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var results = (from billables in data.Accounting_RecurringBillables
                                   where billables.Status == "Enabled" &&
                                         billables.Position <= DateTime.UtcNow
                                   select billables);

                    while (results.Count() > 0)
                    {
                         var set = results.Take<Accounting_RecurringBillables>(10);
                         foreach (Accounting_RecurringBillables billable in set)
                         {
                              billable.PushUnbilledItems();
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
