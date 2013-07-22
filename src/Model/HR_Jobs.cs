using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Weavver.Web;
using System.Web.Security;
using System.Web;

namespace Weavver.Data
{
     [MetadataType(typeof(HR_Jobs.Metadata))]
     [DisplayName("Jobs")]
     [DisplayColumn("Title")]
     [DataAccess(TableView.List, "Administrators", "Guest")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class HR_Jobs : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [FilterUIHint("String")]
               public object Title;

               [FilterUIHint("String")]
               public object Location;

               [FilterUIHint("String")]
               public object Description;

               [HideColumnIn(PageTemplate.List)]
               public object Bonus;

               [HideColumnIn(PageTemplate.List)]
               public object Responsibilities;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Apply", "Administrators", "Guest")]
          public DynamicDataWebMethodReturnType Apply()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectWidth = 800;
               ret.RedirectHeight = 500;
               ret.RedirectURL = "~/HR_Applications/Details.aspx";
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public static List<WeavverMenuItem> GetTableMenu()
          {
               List<WeavverMenuItem> items = new List<WeavverMenuItem>();

               //if (HttpContext.Current.User.IsInRole("Administrators"))
               {
                    WeavverMenuItem item = new WeavverMenuItem();
                    item.Name = "Apply";
                    item.Link = "~/HR_Applications/Details.aspx";
                    items.Add(item);
               }
               return items;
          }
//-------------------------------------------------------------------------------------------
          // we put this to HR_Description in Settings["OrganizationId"]
          //Weavver is an emerging company with interests in building VoIP related services and applications
          //around social networks. We are building and enabling new and interesting business models,
          //while still enjoying the benefits of working and contributing to open source projects.


          //"The following details are for an available position at {COMPANY}"
     }
}
