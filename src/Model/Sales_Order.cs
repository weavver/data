using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Drawing;
using System.IO;

using Weavver.Utilities;
using System.Runtime.Serialization;
using System.Data.Objects.DataClasses;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_Order.Metadata))]
     [DisplayName("Orders")]
     [DisplayColumn("PrimaryContactEmail", "CreatedAt", true)]
     partial class Sales_Order : IAuditable, IValidator
     {
          [SecureTable(TableActions.List, "Administrators", "Employee")]
          [SecureTable(TableActions.Edit, "Administrators", "Employee")]
          [SecureTable(TableActions.Details, "Administrators", "Employee")]
          [SecureTable(TableActions.Delete, "Administrators", "Employee")]
          [SecureTable(TableActions.Insert, "Administrators", "Employee")]
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name = "Ordered At", Order = 1)]
               [ReadOnly(true)]
               public object CreatedAt;

               [Display(Order = 2)]
               public object OrderNum;

               [Display(Order = 3)]
               [ReadOnly(true)]
               [FilterUIHint("String")]
               public object Status;

               [Display(Name = "Orderee", Order = 4)]
               public object OrdereeData;

               [DisplayFormat(DataFormatString = "{0:C}")]
               [Display(Order = 5)]
               [ReadOnly(true)]
               public object Total;

               [HideColumnIn(PageTemplate.List)]
               [Display(Order = 7)]
               [FilterUIHint("String")]
               public object Notes;

               [Display(Name = "First Name", Order = 10)]
               [FilterUIHint("String")]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactNameFirst;

               [Display(Name = "Last Name", Order = 11)]
               [FilterUIHint("String")]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactNameLast;

               [FilterUIHint("String")]
               [Display(Name = "Email", Order = 12)]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactEmail;

               [Display(Name = "Organization", Order = 13)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               [ColumnGroupAttribute("Primary Contact")]
               public object PrimaryContactOrganization;

               [Display(Name = "Phone Number", Order = 14)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactPhoneNum;

               [Display(Name = "Phone Number Ext.", Order = 15)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactPhoneExt;

               [Display(Name = "Address", Order = 16)]
               [HideColumnIn(PageTemplate.List)]
               [ColumnGroup("Primary Contact")]
               public object PrimaryContactAddressData;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "First Name", Order = 20)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactNameFirst;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Last Name", Order = 21)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactNameLast;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Email", Order = 22)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactEmail;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Organization", Order = 23)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactOrganization;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Phone Number", Order = 24)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactPhoneNum;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Phone Number Ext.", Order = 25)]
               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("String")]
               public object BillingContactPhoneExt;

               [ColumnGroupAttribute("Billing Contact")]
               [Display(Name = "Address", Order = 26)]
               [HideColumnIn(PageTemplate.List)]
               public object BillingContactAddressData;

               [ColumnGroup("Confirmation E-mail")]
               [FilterUIHint("String")]
               [Display(Name = "E-mail", Order = 27)]
               [HideColumnIn(PageTemplate.List)]
               public object Cart;

               [Display(Name = "Entered By", Order = 30)]
               [ReadOnly(true)]
               public object System_Users1;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Updated At", Order = 31)]
               [ReadOnly(true)]
               public object UpdatedAt;

               [Display(Name = "Updated By", Order = 32)]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object System_Users;
          }
//-------------------------------------------------------------------------------------------
          public string PayableToInfo
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var res = (from x in data.Logistics_Organizations
                                    where x.Id == OrganizationId
                                    select x).First();

                         if (res != null)
                         {
                              return res.Name;
                         }

                         return null;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Added convenience accessor to assist with PDF generation
          /// </summary>
          public List<Accounting_LedgerItems> LineItems
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var res = from x in data.Accounting_LedgerItems
                                   where x.AccountId == Id
                                   select x;

                         return res.ToList<Accounting_LedgerItems>();
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Renders as a PNG
          /// </summary>
          public Bitmap QRCode_MakePayment
          {
               get
               {
                    return Weavver.Utilities.QRUtility.GenerateCode(PaymentURL , 100);
               }
          }
//-------------------------------------------------------------------------------------------
          public string PaymentURL
          {
               get
               {
                    return "https://" + HttpContext.Current.Request.Url.Host + "/workflows/accounting_makepayment?orderid=" + Id.ToString();
               }
               set
               {
               }
          }
//-------------------------------------------------------------------------------------------
          public static byte[] ImageToByteArray(Image img)
          {
               byte[] byteArray = new byte[0];
               using (MemoryStream stream = new MemoryStream())
               {
                    img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    stream.Close();

                    byteArray = stream.ToArray();
               }
               return byteArray;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Download Invoice", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType DownloadInvoice()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.FilePath = GeneratePDF();
               ret.FileMimeType = "application/octet-stream";
               ret.FileName = "Invoice X.pdf";
               //ret.RedirectRequest = true;
               //ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("View Line Items", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ViewLineItems()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "/Accounting_LedgerItems/List.aspx?AccountId=" + Id.ToString() + "&LedgerType=Receivable";
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("View Transaction", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType ViewTransaction()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "/Accounting_LedgerItems/List.aspx?TransactionId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               if (Status == null)
                    Status = "Placed";

               Valid = true;
               ErrorMessage = null;
          }
     }
//-------------------------------------------------------------------------------------------
     public class Sales_OrderReportSettings
     {
          public byte[] HeaderLogo { set; get; }
          public byte[] QRCode_MakePayment { set; get; }
          public string PaymentURL { set; get; }
          public string InvoiceTotal { set; get; }
          public string ClientContactInfo { set; get; }
          public string VendorContactInfo { set; get; }
          public List<Accounting_LedgerItems> LineItems { set; get; }
     }
//-------------------------------------------------------------------------------------------
}