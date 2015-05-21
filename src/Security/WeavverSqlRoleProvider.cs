using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Weavver.Security
{
     public class WeavverSqlRoleProvider : System.Web.Security.SqlRoleProvider
     {
          public override string ApplicationName
          {
               get
               {
                    if (HttpContext.Current.Items.Contains("ApplicationName"))
                         return (string) HttpContext.Current.Items["ApplicationName"];
                    else
                         return "Weavver";
               }
               set
               {
                    base.ApplicationName = value;
               }
          }
     }
}