using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using System.Web;

using PDFjet.NET;
using System.IO;

using Weavver.Utilities;
using Microsoft.Reporting.WebForms;

namespace Weavver.Data
{
     /// <summary>
     /// InvoiceReport
     /// </summary>
     public partial class Sales_Orders
     {
//-------------------------------------------------------------------------------------------
          public Sales_OrderReportSettings ReportSettings
          {
               get
               {
                    Sales_OrderReportSettings settings = new Sales_OrderReportSettings();

                    string LogoPath = @"C:\Weavver\Main\Servers\web\c\Inetpub\www\images\logo.png";
                    if (File.Exists(LogoPath))
                    {
                         settings.HeaderLogo = File.ReadAllBytes(LogoPath);
                    }

                    settings.PaymentURL = PaymentURL;
                    settings.QRCode_MakePayment = ImageToByteArray(QRCode_MakePayment);
                    settings.LineItems = LineItems;
                    string toName = BillingContactNameFirst + " " + BillingContactNameLast + "\r\n";
                    toName = toName + BillingContactOrganization + "\r\n";
                    if (BillingContactAddressData != null)
                         toName += BillingContactAddressData.ToString();
                    settings.ClientContactInfo = toName;

                    settings.VendorContactInfo = PayableToInfo;
                    settings.InvoiceTotal = Total.Value.ToString("C");
                    return settings;
               }
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// This method generates a PDF invoice to be sent out.
          /// </summary>
          /// <param name="db"></param>
          /// <param name="invoice"></param>
          /// <returns>Returns the path to the PDF file on the local file system.</returns>
          public string GeneratePDF()
          {
               // Variables
               Warning[] warnings;
               string[] streamIds;
               string mimeType = string.Empty;
               string encoding = string.Empty;
               string extension = string.Empty;

               List<Sales_Orders> orders = new List<Sales_Orders>();
               orders.Add(this);

               // Setup the report viewer object and get the array of bytes
               ReportViewer viewer = new ReportViewer();
               viewer.ProcessingMode = ProcessingMode.Local;
               viewer.LocalReport.EnableHyperlinks = true;
               viewer.LocalReport.DataSources.Add(new ReportDataSource("Sales_Order", orders));

               List<Sales_OrderReportSettings> settings = new List<Sales_OrderReportSettings>();
               settings.Add(ReportSettings);
               viewer.LocalReport.DataSources.Add(new ReportDataSource("Sales_OrderReportSettings", settings));

               viewer.LocalReport.DataSources.Add(new ReportDataSource("Accounting_LedgerItems", LineItems));

               viewer.LocalReport.ReportPath = @"C:\Weavver\Main\Projects\WeavverLib\Exports\Sales_Order_Invoice.rdlc";

               byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

               string filepath = System.IO.Path.GetTempFileName() + ".pdf";
               File.WriteAllBytes(filepath, bytes);
               return filepath;
          }
//-------------------------------------------------------------------------------------------
     }
}


//-------------------------------------------------------------------------------------------
//public void SendInvoice(string destination)
//{
//     MailMessage msg = new System.Net.Mail.MailMessage("Weavver Accounting <accounting@weavver.com>", destination);
//     msg.Subject = "Invoice from Weavver, Inc.";
//     string filepath = GeneratePDF();
//     string body = "We have attached your invoice to this e-mail. If you have any questions "
//                 + "please reply to accounting@weavver.com.\r\n\r\n"
//                 + "Summary\r\n\r\n"
//                 + "Date: " + CreatedAt.ToString("MM/dd/yy") + "\r\n"
//                 + "Amount: $" + Total + "\r\n"
//                 //+ "Due By: " + order.DueBy.ToString("MM/dd/yy") + "\r\n\r\n"
//                 + "Please visit https://www.weavver.com/company/accounting/invoicepayment?id=" + Id.ToString() + " to pay your invoice online.\r\n\r\n"
//                 + "Sincerely,\r\nWeavver Accounting\r\n\r\n"
//                 + "------------------------\r\nDelivered by Weavver Accounting";
//     msg.Body = body;
//     Attachment resumeAttachment = new Attachment(filepath);
//     resumeAttachment.Name = "Invoice.pdf";
//     msg.Attachments.Add(resumeAttachment);
//     SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["smtp_address"]);
//     sClient.Send(msg);
//}