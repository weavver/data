using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Data_AuditTrails.Metadata))]
     [DisplayColumn("CreatedAt", "CreatedAt", false)]
     [DisplayName("Audit Trails")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     partial class Data_AuditTrails
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               public object OrganizationId;

               [Display(Name = "Table Name")]
               public object TableName;

               [Display(Name = "Old Data")]
               public object OldData;

               [Display(Name = "New Data")]
               public object NewData;

               [Display(Name = "Changed Columns")]
               public object ChangedColumns;

               [Display(Name="Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [ReadOnly(true)]
               public object System_Users;
          }
     }
}