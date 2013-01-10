using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

namespace Weavver.Vendors.PayPal.Data
{
     public class PayPalRecord
     {
//-------------------------------------------------------------------------------------------
          public string Date { get; set; }                       // 2/14/2008;
          public string Time { get; set; }                       // 10:13:39;
          public string TimeZone { get; set; }                   // PST;
          public string Name { get; set; }                       // Infodomèstics SA;
          public string Type { get; set; }                       // Web Accept Payment Received;
          public string Status { get; set; }                     // Completed; //
          public string Currency { get; set; }                   // USD;
          public string Gross { get; set; }                      // 29.99;Fee = -1.47;
          public string Net { get; set; }                        // 28.52;
          public string FromEmailAddress  { get; set; }          // informatica@example.com;
          public string ToEmailAddress  { get; set; }            // paypal@domain.com;
          public string TransactionID { get; set; }              // 13242431341;
          public string CounterpartyStatus { get; set; }         // Non-U.S. - Unverified;
          public string ShippingAddress { get; set; }            //
          public string AddressStatus { get; set; }              //
          public string ItemTitle { get; set; }                  // Snap Pro;
          public string ItemID { get; set; }                     // 01;
          public decimal ShippingandHandlingAmount { get; set; } // 0.00;
          public string InsuranceAmount { get; set; }            //
          public decimal SalesTax { get; set; }                  // 0.00;
          public string Option1Name { get; set; }                //
          public string Option1Value { get; set; }               //
          public string Option2Name { get; set; }                //
          public string Option2Value { get; set; }               //
          public string AuctionSite { get; set; }                //
          public string BuyerID { get; set; }                    //
          public string ReferenceTxnID { get; set; }             //
          public string InvoiceNumber { get; set; }              //
          public string CustomNumber { get; set; }               // 559
          public string ReceiptID { get; set; }                  //
          public string Balance { get; set; }                    // 1,082.43;
          public string ContactPhoneNumber { get; set; }         // 
          public string BalanceImpact { get; set; }              // Credit
          public DateTime EnteredAt { get; set; }
          public string EnteredBy { get; set; }
//-------------------------------------------------------------------------------------------
          public PayPalRecord() : base()
          {
               Type = "Weavver.Vendors.Paypal.Data.PayPalRecord";
          }
//-------------------------------------------------------------------------------------------
     }
}