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
                                         billables.UnbilledPeriods > 0
                                   select billables);

                    Console.WriteLine("Total ARB items to process: " + results.Count() + " (100 processed at a time only)");
                    var set = results.Take<Accounting_RecurringBillables>(100);
                    foreach (Accounting_RecurringBillables billable in set)
                    {
                         Console.WriteLine("Pushing unbilled items for ARB Item " + billable.Id.ToString());
                         billable.PushUnbilledItems();
                    }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
