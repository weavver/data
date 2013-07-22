using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Accounting_Checks.Metadata))]
     [DisplayName("Checks")]
     [DataAccess(TableView.List, "Administrators", "Accountants", Height=588, Width=987)]
     [DataAccess(RowView.Edit, "Administrators", "Accountants", Height = 588, Width = 987)]
     [DataAccess(RowView.Details, "Administrators", "Accountants", Width = 836, Height = 415)]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants", Height = 588, Width = 987)]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants")]
     [DisplayColumn("Memo", "PostAt", true)]
     partial class Accounting_Checks : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [HideColumnIn(PageTemplate.List)]
               public object ExternalId;

               [Display(Order = 1)]
               public object Status;

               [Display(Name = "Funding Source", Order = 2)]
               public object Accounting_Accounts;

               [Display(Name = "Posted", Order = 5)]
               [DisplayFormat(DataFormatString = "{0:MM/dd/yy}")]
               [DataTypeAttribute(DataType.Date)]
               [UIHint("Date")]
               public object PostAt;

               [Display(Name = "Number", Order = 10)]
               public object CheckNumber;

               [Display(Name="Payee", Order=11)]
               public object PayeeAccount;

               [Display(Order=20)]
               [DefaultValue("[no memo]")]
               public object Memo;

               [DisplayFormat(DataFormatString="{0:C}")]
               [Display(Order = 25)]
               public object Amount;

               [Display(Name = "Created At")]
               [FilterUIHint("DateTime")]
               [ScaffoldColumn(false)]
               public object CreatedAt;

               [Display(Name = "Updated At")]
               [FilterUIHint("DateTime")]
               [ScaffoldColumn(false)]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;
          }
//-------------------------------------------------------------------------------------------
          public Logistics_Addresses BillingAddress
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var billingAccount = (from org in data.Logistics_Organizations
                                               where org.OrganizationId == OrganizationId &&
                                                     org.Id == OrganizationId
                                               select org).First();

                         var addressObject = (from addy in data.Logistics_Addresses
                                              where addy.OrganizationId == OrganizationId &&
                                                    addy.Id == billingAccount.BillingAddress
                                                    select addy).First();

                         return addressObject;
                    }
                    return null;
               }
          }
//-------------------------------------------------------------------------------------------
          public string PayeeName
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         return data.GetName(Payee).ToString();
                    }
                    return "unknown";
               }
          }
//-------------------------------------------------------------------------------------------
          public Logistics_Addresses PayeeAddress
          {
               get
               {
                    using (WeavverEntityContainer data = new WeavverEntityContainer())
                    {
                         var payeeAccount = (from orgs in data.Logistics_Organizations
                                             where orgs.Id == Payee
                                             select orgs).First();

                         if (payeeAccount.BillingAddress.HasValue)
                         {
                              var payeeAddress = (from addy in data.Logistics_Addresses
                                                  where addy.OrganizationId == OrganizationId &&
                                                  addy.Id == payeeAccount.BillingAddress
                                                  select addy).First();

                              return payeeAddress;
                         }
                    }
                    return null;
               }
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Download Printable PDF", "Administrators", "Accountants", RequiresPostback=true)]
          public DynamicDataWebMethodReturnType DownloadPrintablePDF()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.FilePath = GeneratePDF();
               ret.FileMimeType = "application/octet-stream";
               ret.FileName = "Check " + CheckNumber.ToString() + ".pdf";
               //ret.RedirectRequest = true;
               //ret.RedirectURL = "~/Accounting_LedgerItems/List.aspx?AccountId=" + AccountId.ToString() + "&LedgerType=" + LedgerType.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Send via Bill Pay", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType SendviaBillPay()
          {
               // check if there is an OFX settings record for the selected Funding Source
               // do a search on the server sidepayees for the payeeid
                    // if the payee does not exist, create it and get the payeeid
               
               // we now have the payeeid


               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "Not implemented.";
               ret.Message = "Not implemented.";
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}