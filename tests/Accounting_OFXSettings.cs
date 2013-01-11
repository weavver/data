using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

namespace Weavver.Testing.Accounting
{
     //[TestFixture]
     public class Accounting_OFXSettingsTest
     {
//-------------------------------------------------------------------------------------------
          private Accounting_OFXSettings GetOFXSampleObj()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Guid testObjectId = new Guid(Helper.GetAppSetting("accounting_ofxsettings_testobjectid"));
                    var ofxSettings = (from x in data.Accounting_OFXSettings
                                        where x.Id == testObjectId
                                        select x).FirstOrDefault();

                    data.Detach(ofxSettings);

                    Assert.IsNotNull(ofxSettings, "could not get the ofx testing object");

                    return ofxSettings;
               }
          }
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void UpdateCachedBalances()
          {
               var ofxSettings = GetOFXSampleObj();
               var ret = ofxSettings.UpdateCachedBalances();
               Assert.IsTrue(ret.Message.Contains("Balances updated."), "The balances couldn't be updated.");
          }
//-------------------------------------------------------------------------------------------
          [StagingTest]
          public void ImportLedgeritems()
          {
               var ofxSettings = GetOFXSampleObj();
               var ret = ofxSettings.ImportLedgerItems();
               Assert.IsTrue(ret.Message.Contains("Items added/updated"), "The ledger items could not be retrieved.");
          }
//-------------------------------------------------------------------------------------------
     }
}
