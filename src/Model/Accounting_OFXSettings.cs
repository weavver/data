using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;
using nsoftware.InEBank;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Accounting_OFXSettings.Metadata))]
     [DisplayName("OFX Settings")]
     [DataAccess(TableView.List, "Administrators", "Accountants", Width=912, Height=494)]
     [DataAccess(RowView.Edit, "Administrators", "Accountants", Width = 912, Height = 494)]
     [DataAccess(RowView.Details, "Administrators", "Accountants", Width = 912, Height = 494)]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants", Width = 912, Height = 494)]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants", Width = 912, Height = 494)]
     [DisplayColumn("AccountId", "AccountId", true)]
     [ScaffoldTable(true)]
     partial class Accounting_OFXSettings : IAuditable
     {
//-------------------------------------------------------------------------------------------
          private PayeeDetailList _RemotePayees = null;
//-------------------------------------------------------------------------------------------
          public PayeeDetailList RemotePayees
          {
               get
               {
                    if (_RemotePayees == null)
                    {
                         var billPaymentData = GetOFXBillPaymentObject();
                         billPaymentData.SynchronizePayees("REFRESH");
                         _RemotePayees = billPaymentData.SyncPayees;
                    }
                    return _RemotePayees;
               }
          }
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name="Account", Order = 1)]
               public object Accounting_Accounts;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               public object Password;

               [Display(Name = "Financial Institution Id")]
               [HideColumnIn(PageTemplate.List)]
               public object FinancialInstitutionId;
               
               [Display(Name = "Financial Institution Name")]
               [HideColumnIn(PageTemplate.List)]
               public object FinancialInstitutionName;

               [Display(Name = "OFX URL")]
               [HideColumnIn(PageTemplate.List)]
               public object Url;

               [Display(Name = "Bank Id")]
               [HideColumnIn(PageTemplate.List)]
               public object BankId;

               [Display(Name = "Last Successful Connection")]
               [ReadOnly(true)]
               public object LastSuccessfulConnection;

               [Display(Name = "Bank Balance")]
               [DisplayFormat(DataFormatString = "{0:C}")]
               [ReadOnly(true)]
               public object LedgerBalance;

               [Display(Name = "Pending Balance")]
               [DisplayFormat(DataFormatString = "{0:C}")]
               [ReadOnly(true)]
               public object AvailableBalance;

               [Display(Name = "Created At")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object CreatedAt;

               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [Display(Name = "Created By")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [Display(Name = "Updated By")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users1;
          }
//-------------------------------------------------------------------------------------------
          public string GetRemotePayeeIdForOrganization(Guid organizationId)
          {
               return null;
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// 
          /// </summary>
          /// <param name="organizationId"></param>
          /// <returns>This returns the PayeeId on the server.</returns>
          public string CreatePayeeData(Logistics_Organizations payee)
          {
               Billpayment paymentData = GetOFXBillPaymentObject();

               PayeeDetail item = new PayeeDetail();
               //item.Id = "1234";

               item.Account = payee.Id.ToString().Replace("-", "");
               item.Name = "John Doe";
               item.Addr1 = "Line 1b";
               item.Addr2 = "Line 2b";
               item.Addr3 = "Line 3";
               item.City = "Weavverville";
               item.State = "CA";
               item.PostalCode = "92832";
               item.Country = "USA";
               item.Phone = "7148531212";

               paymentData.Payee = item;

               paymentData.AddPayee();
               return item.ListId;
          }
//-------------------------------------------------------------------------------------------
          public List<Accounting_OFXLedgerItem> GetRemoteLedgerItems(DateTime startDate, DateTime endDate)
          {
               Accounting_Accounts account = GetAccount();
               if (((LedgerType)Enum.Parse(typeof(LedgerType), account.LedgerType)) == LedgerType.CreditCard)
               {
                    return LoadCreditCardStatement(startDate, endDate);
               }
               else
               {
                    return LoadBankStatement(startDate, endDate);
               }
          }
//-------------------------------------------------------------------------------------------
          private List<Accounting_OFXLedgerItem> LoadCreditCardStatement(DateTime startAt, DateTime endAt)
          {
               Accounting_Accounts account = GetAccount();
               List<Accounting_OFXLedgerItem> items = new List<Accounting_OFXLedgerItem>();
               nsoftware.InEBank.Ccstatement statement = GetCreditCardStatement(account, startAt, endAt);
               for (int i = 0; i < statement.Transactions.Count; i++)
               {
                    TransactionDetail detail = statement.Transactions[i];
                    Accounting_OFXLedgerItem item = new Accounting_OFXLedgerItem();
                    item.LedgerItem = new Accounting_LedgerItems();
                    //string md5 = Weavver.Utilities.Common.MD5(detail.Date + detail.PayeeName + detail.Amount);
                    item.LedgerItem.Id = Guid.NewGuid();
                    item.LedgerItem.OrganizationId = OrganizationId;
                    item.LedgerItem.AccountId = AccountId;
                    item.LedgerItem.LedgerType = account.LedgerType;
                    item.LedgerItem.ExternalId = detail.FITID;
                    item.LedgerItem.PostAt = DateTime.Parse(detail.DatePosted).ToUniversalTime();
                    //// statement.Transactions[i].TypeDescription: Credit/Debit
                    item.LedgerItem.Memo = detail.PayeeName;
                    if (detail.TxType == TTxTypes.ttCredit)
                    {
                         item.LedgerItem.Code = CodeType.Payment.ToString();
                    }
                    else
                    {
                         item.LedgerItem.Code = CodeType.Withdrawal.ToString();
                    }
                    item.LedgerItem.Amount = Convert.ToDecimal(statement.Transactions[i].Amount);
                    items.Add(item);
               }
               return items;
          }
//-------------------------------------------------------------------------------------------
          public Bankstatement GetBankStatement(Accounting_Accounts acct, DateTime startDate, DateTime endDate)
          {
               Bankstatement item = new Bankstatement();
               item.Firewall.AutoDetect = false;
               item.Firewall.FirewallType = FirewallTypes.fwNone;
               item.OFXAppId = "QWIN";
               item.OFXAppVersion = "1700";
               item.FIUrl = Url;
               item.FIId = FinancialInstitutionId.ToString();
               item.FIOrganization = FinancialInstitutionName;
               item.BankId = BankId;
               item.AccountId = acct.AccountNumber;
               item.AccountType = ConvertWeavverLedgerTypeToEbankingBankStatementAccountType((LedgerType) Enum.Parse(typeof(LedgerType), acct.LedgerType));
               item.OFXUser = Username;
               item.OFXPassword = Password;
               //item.IncludeImages = true; // Not working
               //item.OFXVersion = "211";
               item.StartDate = startDate.ToString("MM/dd/yyyy hh:mm:ss");
               item.EndDate = endDate.ToString("MM/dd/yyyy hh:mm:ss");
               item.GetStatement();
               return item;
          }
//-------------------------------------------------------------------------------------------
          private Accounting_Accounts GetAccount()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Accounting_Accounts acct = (from x in data.Accounting_Accounts
                                                where x.Id == AccountId.Value
                                                select x).FirstOrDefault();

                    data.Accounting_Accounts.Detach(acct);
                    return acct;
               }
          }
//-------------------------------------------------------------------------------------------
          private List<Accounting_OFXLedgerItem> LoadBankStatement(DateTime startDate, DateTime endDate)
          {
               Accounting_Accounts account = GetAccount();
               nsoftware.InEBank.Bankstatement statement = GetBankStatement(account, startDate, endDate);

               List<Accounting_OFXLedgerItem> items = new List<Accounting_OFXLedgerItem>();
               for (int i = 0; i < statement.Transactions.Count; i++)
               {
                    TransactionDetail detail = statement.Transactions[i];
                    Accounting_OFXLedgerItem item = new Accounting_OFXLedgerItem();
                    item.LedgerItem = new Accounting_LedgerItems();
                    item.LedgerItem.Id = Guid.NewGuid();
                    item.LedgerItem.OrganizationId = OrganizationId;
                    item.LedgerItem.AccountId = account.Id;
                    item.LedgerItem.LedgerType = account.LedgerType;
                    // Weavver.Utilities.Common.MD5(detail.Date + detail.PayeeName + detail.Amount);
                    item.LedgerItem.ExternalId = detail.FITID;
                    item.LedgerItem.PostAt = DateTime.Parse(detail.DatePosted).ToUniversalTime();
                    if (detail.Memo == "Withdrawal Draft")
                    {
                         item.CheckNumber = Convert.ToInt32(detail.CheckNumber);
                         item.LedgerItem.Memo = "Check #" + detail.CheckNumber; // converting removes leading zeroes
                         // later:
                         // cross reference the check number against #checks
                         // double check the amount matches
                         // link the transactions
                         // mark the check as cleared
                    }
                    else if (detail.TypeDescription == "Debit")
                    {
                         if (detail.Memo.Contains(detail.PayeeName))
                              item.LedgerItem.Memo = detail.Memo;
                         else
                              item.LedgerItem.Memo = detail.PayeeName + detail.Memo;
                    }
                    else if (detail.TypeDescription == "Credit")
                    {
                         if (statement.Transactions[i].Memo.Contains(detail.PayeeName))
                              item.LedgerItem.Memo = detail.Memo;
                         else
                              item.LedgerItem.Memo = detail.PayeeName + detail.Memo;
                    }
                    else if (detail.TxType == nsoftware.InEBank.TTxTypes.ttATM)
                    {
                         item.LedgerItem.Memo = detail.PayeeName;
                    }
                    else if (detail.TxType == nsoftware.InEBank.TTxTypes.ttCheck)
                    {
                         //BILL PAY CHECK
                         if (detail.PayeeName == "BILL PAY CHECK")
                         {
                              item.LedgerItem.Memo = "BILL PAY CHECK " + detail.CheckNumber;
                         }
                         else
                         {
                              item.LedgerItem.Memo = detail.TypeDescription + " " + detail.CheckNumber;
                         }
                         item.CheckNumber = Int32.Parse(detail.CheckNumber);
                    }
                    else
                    {
                         // a catch all
                         item.LedgerItem.Memo = detail.TypeDescription + " " + detail.CheckNumber;
                    }
                    item.LedgerItem.Amount = Convert.ToDecimal(detail.Amount);
                    if (item.LedgerItem.Amount < 0)
                    {
                         item.LedgerItem.Code = CodeType.Withdrawal.ToString();
                    }
                    else
                    {
                         item.LedgerItem.Code = CodeType.Deposit.ToString();
                    }

                    //row[4] = Accounting.MatchAndLog((DateTime)row[1], row[2].ToString(), (decimal)row[3]);

                    items.Add(item);
               }
               return items;
          }
//-------------------------------------------------------------------------------------------
          public Ccstatement GetCreditCardStatement(Accounting_Accounts acct, DateTime startDate, DateTime endDate)
          {
               nsoftware.InEBank.Ccstatement item = new nsoftware.InEBank.Ccstatement();
               item.OFXAppId = "QWIN";
               item.OFXAppVersion = "1800";
               item.FIUrl = Url;
               item.FIId = FinancialInstitutionId.ToString();
               item.FIOrganization = FinancialInstitutionName;
               item.CardNumber = acct.AccountNumber;
               item.OFXUser = Username;
               item.OFXPassword = Password;
               item.StartDate = startDate.ToString("MM/dd/yyyy hh:mm:ss");
               item.EndDate = endDate.ToString("MM/dd/yyyy hh:mm:ss");
               item.GetStatement();
               return item;
          }
//-------------------------------------------------------------------------------------------
          private Billpayment SendPaymentViaBillPay(Accounting_Checks check)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var financialAccount = (from x in data.Accounting_Accounts
                                            where x.Id == AccountId
                                            select x).First();

                    Logistics_Addresses address = null;

                    Billpayment billPayment = new Billpayment();
                    billPayment.FIUrl = Url;
                    billPayment.FIId = FinancialInstitutionId.ToString();
                    billPayment.FIOrganization = FinancialInstitutionName;
                    billPayment.OFXUser = Username;
                    billPayment.OFXPassword = Password;

                    billPayment.Payment.FromBankId = BankId;
                    billPayment.Payment.FromAccountId = financialAccount.AccountNumber;
                    billPayment.Payment.FromAccountType = ConvertWeavverLedgerTypeToEbankingAccountType((LedgerType) Enum.Parse(typeof(LedgerType), financialAccount.LedgerType));
                    billPayment.Payment.Memo = check.Memo;
                    billPayment.Payment.Amount = check.Amount.ToString();
                    billPayment.Payment.DateDue = check.PostAt.ToString("MM/dd/yy");

                    billPayment.Payee.Account = check.Payee.ToString();
                    billPayment.Payee.State = address.State;
                    billPayment.Payee.Addr1 = address.Line1;
                    billPayment.PayBill();

                    // response stuff
                    //lblCurrency.Text = billpayment1.Payment.CurrencyCode;
                    //lblPaymentId.Text = billpayment1.Payment.Id;
                    //lblPaymentDate.Text = billpayment1.Payment.DateProcessed;
                    //lblStatus.Text = billpayment1.Payment.Status;
                    //lblCheckNumber.Text = billpayment1.Payment.CheckNumber;

                    return billPayment;
               }

               // , "Bill payment completed successfully! If payment was a scheduled transaction (not immediate), make a note of the Payment ID if want to modify or cancel this payment at a later time.", "Bill Payment Acknowledgment", MessageBoxButtons.OK, MessageBoxIcon.Information);
          }
//-------------------------------------------------------------------------------------------
          public static AccountTypes ConvertWeavverLedgerTypeToEbankingAccountType(LedgerType accountType)
          {
               switch (accountType)
               {
                    case LedgerType.Checking: return AccountTypes.atChecking;
                    case LedgerType.CreditLine: return AccountTypes.atLineOfCredit;
                    case LedgerType.MoneyMarket: return AccountTypes.atMoneyMarket;
                    case LedgerType.Savings: return AccountTypes.atSavings;
               }
               return AccountTypes.atChecking;
          }
//-------------------------------------------------------------------------------------------
          public static BankstatementAccountTypes ConvertWeavverLedgerTypeToEbankingBankStatementAccountType(LedgerType accountType)
          {
               switch (accountType)
               {
                    case LedgerType.Checking: return BankstatementAccountTypes.atChecking;
                    case LedgerType.CreditCard: return BankstatementAccountTypes.atCreditCard;
                    case LedgerType.CreditLine: return BankstatementAccountTypes.atLineOfCredit;
                    case LedgerType.MoneyMarket: return BankstatementAccountTypes.atMoneyMarket;
                    case LedgerType.Savings: return BankstatementAccountTypes.atSavings;
               }
               return BankstatementAccountTypes.atSavings;
          }
//-------------------------------------------------------------------------------------------
//          [DynamicDataWebMethod("Create Payee", "Administrators", "Accountants")]
//          public DynamicDataWebMethodReturnType CreatePayee()
//          {
//               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
//               ret.Status = "Testing";
//               ret.Message = "ListId: ";
//               using (WeavverEntityContainer data = new WeavverEntityContainer())
//               {
//                    var org = (from x in data.Logistics_Organizations
//                               where x.OrganizationId == new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95")
//                               select x).FirstOrDefault();

//                    if (org != null)
//                    {
//                         string listid = CreatePayeeData(org);
//                         ret.Message += listid.ToString();
//                    }
//               }

//               return ret;
//          }
////-------------------------------------------------------------------------------------------
//          [DynamicDataWebMethod("Import Bill Payment Data", "Administrators", "Accountants")]
//          public DynamicDataWebMethodReturnType ImportBillPaymentData()
//          {
//               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
//               ret.Status = "Importing";
//               ret.Message = "Checks Imported/Updated: ";

//               int addedItems = ImportScheduledPayments();
//               ret.Message += addedItems.ToString();
//               return ret;
//          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Test Connection", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType TestConnection()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "OFX Check";

               var financialAccount = GetAccount();

               if (financialAccount.LedgerType != LedgerType.CreditCard.ToString())
               {
                    nsoftware.InEBank.Account account = new nsoftware.InEBank.Account();
                    account.Firewall.AutoDetect = false;
                    account.Firewall.FirewallType = nsoftware.InEBank.FirewallTypes.fwNone;
                    account.FIUrl = Url;
                    account.FIOrganization = FinancialInstitutionName;
                    account.FIId = FinancialInstitutionId.ToString();
                    account.OFXAppId = "QWIN";
                    account.OFXAppVersion = "1800";
                    account.OFXUser = Username;
                    account.OFXPassword = Password;
                    try
                    {
                         account.GetInfo();

                         ret.Message = "The connection succeeded.";
                    }
                    catch (Exception ex)
                    {
                         ret.Message = "The OFX connection failed: " + ex.Message;
                    }
               }
               else
               {
                    ret.Message = "We can't test credit card connections yet.";
               }
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Update Cached Balances", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType UpdateCachedBalances()
          {
               // call UpdateCachedBalances() instead ??

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "Balance Update";
               decimal remoteAvailableBalance = 0.0m;
               decimal remoteLedgerBalance = 0.0m;
               bool retrieved = GetBalances(GetAccount(), out remoteAvailableBalance, out remoteLedgerBalance);
               if (retrieved)
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var ofxSettings = (from x in data.Accounting_OFXSettings
                                            where x.Id == Id
                                            select x).FirstOrDefault();

                         ofxSettings.AvailableBalance = remoteAvailableBalance;
                         ofxSettings.LedgerBalance = remoteLedgerBalance;

                         int changes = data.SaveChanges();
                         if (changes > 0)
                         {
                              ret.Message = "Balances updated.";
                              ret.RefreshData = true;
                              return ret;
                         }
                    }
               }
               
               ret.Message = "Could not update the balance.";
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}