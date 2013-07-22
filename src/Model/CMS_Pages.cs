using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Weavver.Data
{
     [MetadataType(typeof(CMS_Pages.Metadata))]
     [DisplayName("Page Content")]
     [DisplayColumn("Title", "Title")]
     [DataAccess(TableView.List, "Administrators", Height=575, Width=775, DisplayName="Page Content")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowView.Page, "Administrators", "Guest")]
     [DataAccess(RowAction.Insert, "Administrators")]
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
               [Display(Name = "Created At")]
               public object CreatedAt;

               [ReadOnly(true)]
               [Display(Name = "Created By")]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Updated At")]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name = "Updated By")]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users1;
          }

     }
}
