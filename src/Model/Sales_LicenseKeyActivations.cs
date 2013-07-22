using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Configuration;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Sales_LicenseKeyActivations.Metadata))]
     [DisplayName("License Key Activations")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [ScaffoldTable(false)]
     partial class Sales_LicenseKeyActivations : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object OrganizationId;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [Display(Name = "License Key", Order = 5)]
               public object Sales_LicenseKeys;

               [Display(Name = "Machine Code", Order = 10)]
               public object MachineCode;

               [Display(Name = "Last Heard From", Order = 15)]
               public object LastHeardFrom;

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
          }
//-------------------------------------------------------------------------------------------
     }
}