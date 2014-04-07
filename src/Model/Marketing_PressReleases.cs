﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Marketing_PressReleases.Metadata))]
     [DisplayName("Press Releases")]
     [DataAccess(TableView.List, "Administrators", "Guest")]
     [DataAccess(TableView.PressRoll, "Administrators", "Guest")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class Marketing_PressReleases : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               public object OrganizationId;

               [Display(Name="Release Date", Order=1)]
               public object PublishAt;

               [HideColumnIn(PageTemplate.List)]
               [HideColumnIn(PageTemplate.Details)]
               [ScaffoldColumn(false)]
               public object Body;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object HTMLBody;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [ReadOnly(true)]
               [Display(Name = "Updated At")]
               public object UpdatedAt;
          }
     }
}