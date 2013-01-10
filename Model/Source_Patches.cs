using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Source_Patches.Metadata))]
     [DisplayName("Patches")]
     partial class Source_Patches : IAuditable
     {
          [SecureTable(TableActions.List, "Administrators")]
          [SecureTable(TableActions.Edit, "Administrators")]
          [SecureTable(TableActions.Details, "Administrators")]
          [SecureTable(TableActions.Delete, "Administrators")]
          [SecureTable(TableActions.Insert, "Administrators")]
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               // PathFile/PatchReason/description
               //Fixes Bug</a
               //New Feature<

               //public object OrganizationId;

               //public object UpdatedAt;

               //public object CreatedBy;
          }
     }
}
