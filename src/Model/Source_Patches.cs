﻿using System;
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
          [DataAccess(TableView.List, "Administrators")]
          [DataAccess(RowView.Edit, "Administrators")]
          [DataAccess(RowView.Details, "Administrators")]
          [DataAccess(RowAction.Delete, "Administrators")]
          [DataAccess(RowAction.Insert, "Administrators")]
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
