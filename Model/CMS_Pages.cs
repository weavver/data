using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Weavver.Data
{
     [MetadataType(typeof(CMS_Pages.Metadata))]
     [DisplayName("CMS Pages")]
     [DisplayColumn("Title", "Title")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators", "Guest")]
     [SecureTable(TableActions.Page, "Administrators", "Guest")]
     [SecureTable(TableActions.Insert, "Administrators")]
     partial class CMS_Pages : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name="Title", Order=1)]
               public object Title;

               [UIHint("Code")]
               [Display(Name = "Body", Order = 2)]
               [HideColumnIn(PageTemplate.List)]
               public object Page;

               [HideColumnIn(PageTemplate.Details)]
               [Display(Name = "Master Page", Order=3)]
               public object MasterPage;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               public object CreatedAt;

               [ReadOnly(true)]
               [Display(Name = "Created By")]
               public object System_Users;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Updated At")]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name="Updated By")]
               public object System_Users1;
          }

     }
}
