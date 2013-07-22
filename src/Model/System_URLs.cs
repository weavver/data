using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(System_URLs.Metadata))]
     [DisplayColumn("Path", "Path", false)]
     [DisplayName("URLs")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class System_URLs : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(true)]
               [Display(Name = "Object Id", Order = 1)]
               public object ObjectId;

               [Display(Name="Path", Order=2)]
               public object Path;

               [Display(Name = "Table Name", Order = 3)]
               public object TableName;

               [Display(Name = "Page Template", Order = 4)]
               public object PageTemplate;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [ReadOnly(true)]
               public object CreatedBy;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedBy;

               [ReadOnly(true)]
               [Display(Name="Created By")]
               public object System_Users;

               [ReadOnly(true)]
               [Display(Name="Updated By")]
               public object System_Users1;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Test URL", "Administrators")]
          public DynamicDataWebMethodReturnType Receivables()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               // real url = String.Format("~/{0}/{1}.aspx?Id={2}", TableName, PageTemplate, ObjectId.ToString());

               ret.RedirectURL = Path;
               ret.RedirectWidth = 800;
               ret.RedirectHeight = 500;
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}