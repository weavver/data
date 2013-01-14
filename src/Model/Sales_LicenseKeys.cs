using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
//using Infralution.Licensing;
using System.Configuration;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Sales_LicenseKeys.Metadata))]
     [DisplayName("License Keys")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
     partial class Sales_LicenseKeys : IAuditable, IValidator
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [Display(Name = "Organization")]
               [ScaffoldColumn(false)]
               public object Logistics_Organizations1;

               [Display(Name = "Assigned To", Order = 10)]
               public object Logistics_Organizations;

               [Display(Name = "AssignedTo", Order = 11)]
               public object AssignedTo;

               [Display(Name = "Full Name", Order = 20)]
               public object FullName;

               [Display(Name = "Organization", Order = 30)]
               public object Organization;

               [Display(Name="Machine Count", Order=35)]
               public object MachineCount;

               [ScaffoldColumn(true)]
               [Display(Name = "Machine Activations", Order = 36)]
               public object Activations;

               [Display(Name = "Concurrent Users Per Machine", Order = 37)]
               public object ConcurrentUsersPerMachine;

               [Display(Name = "Expiration Date", Order = 38)]
               public object ExpirationDate;

               [Display(Name = "Key", Order = 40)]
               public object Key;

               [Display(Name = "Extra XML", Order = 42)]
               public object ExtraXML;

               [Display(Name = "Internal Notes", Order = 45)]
               public object Notes;

               [Display(Name = "Updated At", Order = 75)]
               [ReadOnly(true)]
               public object UpdatedAt;

               [Display(Name = "Updated By", Order = 76)]
               [ReadOnly(true)]
               public object System_Users1;

               [ScaffoldColumn(false)]
               public object UpdatedBy;

               [Display(Name = "Created At", Order = 80)]
               [ReadOnly(true)]
               public object CreatedAt;

               [ScaffoldColumn(false)]
               public object CreatedBy;

               [Display(Name = "Created By", Order = 81)]
               [ReadOnly(true)]
               public object System_Users;

               [ScaffoldColumn(false)]
               public object Sales_LicenseKeyActivations;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Generate Key", "Administrators")]
          public DynamicDataWebMethodReturnType GenerateKey()
          {
               //ushort ushortserial = ushort.Parse("1"); //i.ToString()//key.Id.ToString());
               ////changed sept 7
               //string checksum = EncryptedLicense.Checksum(FullName + "|" + Organization);
               ////DateTime future = DateTime.UtcNow.Add(TimeSpan.FromDays(365));
               //DateTime future = DateTime.UtcNow.Add(TimeSpan.FromDays(545));
               //EncryptedLicenseProvider licenseProvider = new EncryptedLicenseProvider();

               //string licensekey = licenseProvider.GenerateKey(ConfigurationManager.AppSettings["snap_productkey"], "C" + checksum + "$D" + future.Month.ToString() + "/" + future.Day.ToString() + "/" + future.Year.ToString(), ushortserial);
               ////Key = licensekey;

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "License Key";
               ret.Message = "Your license key is:\r\n\r\n";// +licensekey;
               ret.Exception = false;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("View Activations", "Administrators")]
          public DynamicDataWebMethodReturnType ViewActivations()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "~/Sales_LicenseKeyActivations/List.aspx?LicenseKeyId=" + Id.ToString();
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               Valid = true;
               ErrorMessage = "";

               // Add XML validation for the ExtraXML field
          }
//-------------------------------------------------------------------------------------------
     }
}