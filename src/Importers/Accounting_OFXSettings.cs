using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using nsoftware.InEBank;
using Weavver.Utilities;
using Weavver.Web;

namespace Weavver.Data
{
     partial class Accounting_OFXSettings : ICRON
     {
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// </summary>
          public void RunCronTasks(CommandLineArguments args)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    // only load ofx enabled accounts
                    var ofxBanks = from x in data.Accounting_OFXSettings
                                   where x.Enabled == true
                                   select x;

                    foreach (Accounting_OFXSettings ofxSetting in data.Accounting_OFXSettings)
                    {
                         data.Accounting_OFXSettings.Detach(ofxSetting);

                         // 1. Only import Bill Payment data for checking accounts
                         // We do this before ImportingLedgerItems so we can sync the check numbers
                         var financialAccount = ofxSetting.GetAccount();
                         if (financialAccount.LedgerType == LedgerType.Checking.ToString())
                         {
                              ofxSetting.ImportScheduledPayments();
                         }

                         // 2. Import any Ledger Items && Match to checks in our database
                         // -- this should be done AFTER Bill Payment data is imported
                         ofxSetting.ImportLedgerItems();
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public bool GetBalances(Accounting_Accounts account, out decimal AvailableBalance, out decimal LedgerBalance)
          {
               AvailableBalance = 0.0m;
               LedgerBalance = 0.0m;
               try
               {
                    DateTime startDate = DateTime.Now.Subtract(TimeSpan.FromDays(5));
                    DateTime endDate = DateTime.Now;
                    if (account.LedgerType == LedgerType.CreditCard.ToString())
                    {
                         Ccstatement statement = GetCreditCardStatement(account, startDate, endDate);
                         Decimal.TryParse(statement.AvailableBalance, out AvailableBalance);
                         Decimal.TryParse(statement.LedgerBalance, out LedgerBalance);
                    }
                    else
                    {
                         Bankstatement statement = GetBankStatement(account, startDate, endDate);
                         Decimal.TryParse(statement.AvailableBalance, out AvailableBalance);
                         Decimal.TryParse(statement.LedgerBalance, out LedgerBalance);
                    }
                    return true;
               }
               catch (Exception ex)
               {
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          private Billpayment GetOFXBillPaymentObject()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Accounting_Accounts account = GetAccount();

                    Billpayment billPaymentData = new Billpayment();
                    billPaymentData.OFXAppId = "QWIN";
                    billPaymentData.OFXAppVersion = "1700";
                    billPaymentData.FIUrl = Url;
                    billPaymentData.FIId = FinancialInstitutionId.ToString();
                    billPaymentData.FIOrganization = FinancialInstitutionName;
                    billPaymentData.OFXUser = Username;
                    billPaymentData.OFXPassword = Password;

                    billPaymentData.Payment.FromBankId = BankId;
                    billPaymentData.Payment.FromAccountId = account.AccountNumber;
                    LedgerType lType = (LedgerType)Enum.Parse(typeof(LedgerType), account.LedgerType);
                    billPaymentData.Payment.FromAccountType = Accounting_OFXSettings.ConvertWeavverLedgerTypeToEbankingAccountType(lType);
                    return billPaymentData;
               }
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// 
          /// </summary>
          /// <returns>Returns added check count</returns>
          private int ImportScheduledPayments()
          {
               var financialAccount = GetAccount();
               if (financialAccount.LedgerType != LedgerType.Checking.ToString())
                    return -1;

               Billpayment billPaymentData = GetOFXBillPaymentObject();
               billPaymentData.SynchronizePayments("REFRESH");
               billPaymentData.SynchronizePayees("REFRESH");

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    foreach (var remotePayment in billPaymentData.SyncPayments)
                    {
                         Accounting_Checks matchingCheck = (from check in data.Accounting_Checks
                                                            where check.OrganizationId == financialAccount.OrganizationId
                                                            && check.ExternalId == remotePayment.Id
                                                            select check).FirstOrDefault();

                         if (matchingCheck == null)
                         {
                              Accounting_Checks check = new Accounting_Checks();
                              check.Id = Guid.NewGuid();
                              check.OrganizationId = financialAccount.OrganizationId;
                              check.ExternalId = remotePayment.Id;
                              check.AccountId = financialAccount.Id;
                              check.PostAt = DateTime.Parse(remotePayment.DateDue);
                              check.CheckNumber = Int32.Parse(remotePayment.CheckNumber);
                              check.Status = GetStandardCheckStatus(remotePayment.Status);
                              check.Payee = GetOrganizationIdForPayee(remotePayment.PayeeListId);
                              check.Memo = remotePayment.Memo;
                              check.Amount = Decimal.Parse(remotePayment.Amount);

                              data.Accounting_Checks.AddObject(check);
                         }
                         else
                         {
                              if (matchingCheck.Status != "Cleared" && matchingCheck.Status != GetStandardCheckStatus(remotePayment.Status))
                              {
                                   matchingCheck.Status = GetStandardCheckStatus(remotePayment.Status);
                              }
                         }
                    }
                    return data.SaveChanges();
               }
          }
//-------------------------------------------------------------------------------------------
          private string GetStandardCheckStatus(string remoteStatus)
          {
               switch (remoteStatus)
               {
                    case "WILLPROCESSON": return "Queued";
                    case "CANCELEDON": return "Voided";
                    case "PROCESSEDON": return "Mailed";
                    default: return remoteStatus;
               }
          }
//-------------------------------------------------------------------------------------------
          private Guid GetOrganizationIdForPayee(string payeeId)
          {
               PayeeDetail payee = (from x in RemotePayees
                                    where x.ListId == payeeId
                                    select x).FirstOrDefault();
               if (payee == null)
               {
                    return Guid.Empty;
               }
               else if (!String.IsNullOrEmpty(payee.Account))
               {
                    Guid accountId = new Guid(payee.Account);
                    return accountId;
               }
               return Guid.Empty;
          }
//-------------------------------------------------------------------------------------------
          //private void UpdateCachedBalances()
          //{
          //     using (WeavverEntityContainer data = new WeavverEntityContainer())
          //     {
          //          data.Accounting_OFXSettings.Attach(this);

          //          // Set Balances
          //          var financialAccount = GetAccount();

          //          decimal bankAvailableBalance = 0.0m;
          //          decimal bankLedgerBalance = 0.0m;
          //          bool retrieved = GetBalances(financialAccount, out bankAvailableBalance, out bankLedgerBalance);
          //          if (retrieved)
          //          {
          //               AvailableBalance = bankAvailableBalance;
          //               LedgerBalance = bankLedgerBalance;
          //          }
          //          data.SaveChanges();
          //     }
          //}
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Import Ledger Items", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ImportLedgerItems()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "Import Status";
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    //data.Accounting_OFXSettings.Attach(this);
                    DateTime startAt = DateTime.Now.Subtract(TimeSpan.FromDays(7));
                    if (LastSuccessfulConnection.HasValue)
                         startAt = LastSuccessfulConnection.Value;

                    List<Accounting_OFXLedgerItem> items = GetRemoteLedgerItems(startAt, DateTime.Now);
                    foreach (var item in items)
                    {
                         if (!item.HasBeenImported)
                         {
                              data.Accounting_LedgerItems.AddObject(item.LedgerItem);
                         }
                    }
                    LastSuccessfulConnection = DateTime.UtcNow;
                    int results = data.SaveChanges();
                    ret.Message = "Ledger items added/updated: " + results.ToString();
               }
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public List<Web.WeavverMenuItem> GetTableMenu()
          {
               List<WeavverMenuItem> menuItems = new List<WeavverMenuItem>();

               WeavverMenuItem item = new WeavverMenuItem();
               item.Name = "test";
               item.Link = "#";

               menuItems.Add(item);

               return menuItems;
          }
//-------------------------------------------------------------------------------------------
     }
}
