using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Weavver.Data
{
     [MetadataType(typeof(KnowledgeBase.Metadata))]
     [DisplayName("Knowledge Base")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators", "Guest")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
     [DisplayColumn("Title", "Title")]
     partial class KnowledgeBase : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name = "Parent Node", Order = 1)]
               public object KnowledgeBase2;

               [ScaffoldColumn(false)]
               public object KnowledgeBase1;

               [Display(Order = 2)]
               public object Position;

               [Display(Order=3)]
               public object Title;

               [UIHint("Code")]
               [Display(Name = "Body", Order = 5)]
               [HideColumnIn(PageTemplate.List)]
               public object HtmlBody;

               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [Display(Name = "Created By")]
               [ReadOnly(true)]
               public object System_Users_CreatedBy;

               [ReadOnly(true)]
               //[ScaffoldColumn(true)]
               [Display(Name = "Updated At")]
               public object UpdatedAt;

               [ReadOnly(true)]
               //[ScaffoldColumn(true)]
               [Display(Name = "Created By")]
               public object CreatedBy;

               [Display(Name="Updated By")]
               [ReadOnly(true)]
               public object System_Users_UpdatedBy;

               //[ReadOnly(true)]
               //[ScaffoldColumn(true)]
               [Display(Name = "Updated By")]
               public object UpdatedBy;
          }
     }
}
