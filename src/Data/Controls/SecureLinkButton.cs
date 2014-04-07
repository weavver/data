using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web.DynamicData;
using System.Web.Security;
using System.Configuration;

namespace Weavver.Data
{
     /// <summary>
     /// Secures the link button when used for delete actions
     /// </summary>
     public class SecureLinkButton : LinkButton
     {
          private const String DISABLED_NAMES = "SecureLinkButtonDeleteCommandNames";
          private String[] delete = new String[] { "delete" };
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Raises the <see cref="E:System.Web.UI.Control.Init"/> event.
          /// </summary>
          /// <param name="e">
          /// An <see cref="T:System.EventArgs"/> 
          /// object that contains the event data.
          /// </param>
          protected override void OnInit(EventArgs e)
          {
               if (ConfigurationManager.AppSettings.AllKeys.Contains(DISABLED_NAMES))
                    delete = ConfigurationManager.AppSettings[DISABLED_NAMES]
                        .ToLower()
                        .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

               base.OnInit(e);
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Renders the control to the specified HTML writer.
          /// </summary>
          /// <param name="writer">
          /// The <see cref="T:System.Web.UI.HtmlTextWriter"/> 
          /// object that receives the control content.
          /// </param>
          protected override void Render(HtmlTextWriter writer)
          {
               if (!IsDisabled())
                    base.Render(writer);
               else
                    writer.Write(String.Format("<a>{0}</a>", Text));
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Determines whether this instance is disabled.
          /// </summary>
          /// <returns>
          /// 	<c>true</c> if this instance is 
          /// 	disabled; otherwise, <c>false</c>.
          /// </returns>
          private Boolean IsDisabled()
          {
               // get restrictions for the current
               // users access to this table
               var table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
               var usersRoles = Roles.GetRolesForUser();
               var tableAccess = table.Attributes.OfType<DataAccess>();

               // restrictive permissions
               if (tableAccess.Count() == 0)
                    return true;

               foreach (var accessType in tableAccess)
               {
                    // the LinkButton is considered disabled if delete is denied.
                    var action = CommandName.ToEnum<RowAction>();
                    if (accessType.Actions == RowAction.Delete && accessType.HasAnyRole(usersRoles))
                    {
                         return false;
                    }
               }
               return true;
          }
//-------------------------------------------------------------------------------------------
     }
}
