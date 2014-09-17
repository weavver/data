using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     [Serializable]
     public struct Accounting_OFXLedgerItem
     {
          public bool HasBeenImported
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         Guid organizationId = LedgerItem.OrganizationId;
                         Guid accountId = LedgerItem.AccountId.Value;
                         string externalId = LedgerItem.ExternalId;

                         var financialAccount = (from item in data.Accounting_LedgerItems
                                                 where item.OrganizationId == organizationId &&
                                                       item.AccountId == accountId &&
                                                       item.ExternalId == externalId
                                                 select item).FirstOrDefault();

                         return (financialAccount != null);
                    }
               }
          }
          public int CheckNumber;
          public Accounting_LedgerItems LedgerItem;
     }
}