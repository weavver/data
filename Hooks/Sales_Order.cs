using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Hooks;

namespace Weavver.Data
{
     partial class Sales_Orders : IDatabaseHook
     {
//--------------------------------------------------------------------------------------------
          public void OnSave()
          {
               //Guid resellerId = Guid.Empty;
               //if (resellerId != Guid.Empty)
               //{
               //     Accounting_LedgerItems comission = new Accounting_LedgerItems();
               //     comission.DatabaseHelper = DatabaseHelper;
               //     comission.Id = new Guid();
               //     comission.OrganizationId = OrganizationId;
               //     comission.PostAt = DateTime.UtcNow;
               //     comission.LedgerType = LedgerType.Payable;
               //     comission.Memo = "Order #" + order.Id.ToString();
               //     comission.EntryType = EntryType.Credit;
               //     comission.Code = CodeType.Comission;
               //     comission.Amount = order.Total * .15m; // (hardcoded 15% commission)
               //     comission.CreatedAt = DateTime.UtcNow;
               //     comission.CreatedBy = order.Id;
               //     comission.UpdatedAt = DateTime.UtcNow;
               //     comission.UpdatedBy = order.Id;
               //     comission.Commit();

               //     //DatabaseHelper.Link(order, comission);
               //}
          }
//--------------------------------------------------------------------------------------------
     }
}
