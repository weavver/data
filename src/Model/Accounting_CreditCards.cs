using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using AuthorizeNet;
using System.Configuration;

namespace Weavver.Data
{
     [MetadataType(typeof(Accounting_CreditCards.Metadata))]
     [ScaffoldTable(false)]
     [DisplayName("Credit Cards")]
     [DataAccess(TableView.List, "Administrators", "Accountants")]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants")]
     [DataAccess(RowView.Details, "Administrators", "Accountants", Width = 656, Height = 624)]
     [DataAccess(RowView.Edit, "Administrators", "Accountants")]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants")]
     partial class Accounting_CreditCards : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [UIHint("AccountNumber")]
               [Display(Name = "Card Number", Order=10)]
               public object Number;
               
               //if (item.Number.Length > 4)
               //     PaymentMethod1.CardNumber.Text = "************" + item.Number.Substring(item.Number.Length - 4, 4);
               //PaymentStatus pstatus = BillingMethod1.BillingMethodData.Bill(LoggedInUser.Id, LoggedInUser.Id, 0, "none", Settings.AuthorizeNetTestMode);

               [HideColumnIn(PageTemplate.List)]
               public object Name;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "First Name")]
               public object FirstName;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Last Name")]
               public object LastName;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Email Address")]
               public object EmailAddress;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Address Line 1")]
               public object AddressLine1;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Address Line 2")]
               public object AddressLine2;

               [HideColumnIn(PageTemplate.List)]
               public object State;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Zip Code")]
               public object ZipCode;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Phone Number")]
               public object PhoneNumber;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Phone Extension")]
               public object PhoneExtension;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Expiration Month", Order = 15)]
               public object ExpirationMonth;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Expiration Year", Order = 20)]
               public object ExpirationYear;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Security Code", Order = 25)]
               public object SecurityCode;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [FilterUIHint("DateTime")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;
          }
//-------------------------------------------------------------------------------------------
          public IGatewayResponse Bill(WeavverEntityContainer data, Sales_Orders order, Logistics_Addresses primaryAddress, Logistics_Addresses billingAddress)
          {
               string memo = "WEB PURCHASE";
               // Add the credit to the ledger.
               Accounting_LedgerItems item = new Accounting_LedgerItems();
               item.Id = Guid.NewGuid();
               item.OrganizationId = OrganizationId;
               if (order.Orderee.HasValue)
                    item.AccountId = order.Orderee.Value;
               else
                    item.AccountId = order.Id;
               item.LedgerType = LedgerType.Receivable.ToString();
               item.TransactionId = order.Id;
               item.PostAt = DateTime.UtcNow;
               item.Code = CodeType.Payment.ToString();
               item.Memo = "Payment from Card " + Number.Substring(Number.Length - 4);
               item.Amount = Math.Abs(order.Total.Value);

//               order.BillingContactEmail

               // Submit to Authorize.Net
               var request = new AuthorizationRequest(Number, ExpirationMonth.ToString("D2") + ExpirationYear.ToString("D2"), order.Total.Value, memo, true);
               request.AddCustomer("", order.PrimaryContactNameFirst, order.PrimaryContactNameLast, primaryAddress.Line1, primaryAddress.State, primaryAddress.ZipCode);
               request.AddMerchantValue("OrderId", order.Id.ToString());
               request.AddMerchantValue("CreatedBy", order.CreatedBy.ToString());
               request.AddMerchantValue("LedgerItemId", item.Id.ToString());
               request.AddShipping("", order.BillingContactNameFirst, order.BillingContactNameLast, billingAddress.Line1, billingAddress.State, billingAddress.ZipCode);
               var gate = new Gateway(ConfigurationManager.AppSettings["authorize.net_loginid"], ConfigurationManager.AppSettings["authorize.net_transactionkey"], (ConfigurationManager.AppSettings["authorize.net_testmode"] == "true"));

               var response = gate.Send(request, memo);
               item.ExternalId = response.TransactionID;
               if (!response.Approved)
               {
                    //item.Voided = true;
                    //item.VoidedBy = Guid.Empty;
                    item.Memo += "\r\nPayment failed: Code " + response.ResponseCode + ", " + response.Message;
               }
               data.Accounting_LedgerItems.Add(item);
               return response;
          }
//-------------------------------------------------------------------------------------------
          public string CensoredAccountNumber
          {
               get
               {
                    return "XXXX-XXXX-XXXX-" + ToString();
               }
          }
//-------------------------------------------------------------------------------------------
          public override string ToString()
          {
               if (Number.Length > 4)
               {
                    return Number.Substring(Number.Length - 4, 4);
               }
               else
               {
                    return Number;
               }
          }
//-------------------------------------------------------------------------------------------
     }

//-------------------------------------------------------------------------------------------
     public enum PaymentStatus
     {
          Successful,
          Failed,
          Other
     }
}