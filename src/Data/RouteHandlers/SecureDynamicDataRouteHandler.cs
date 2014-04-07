using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Security;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;

namespace Weavver.Data
{
    /// <summary>
    /// The SecureDynamicDataRouteHandler enables the 
    /// user to access a table based on the following:
    /// the Roles and TableDeny values assigned to 
    /// the SecureTableAttribute.
    /// </summary>
     public class SecureDynamicDataRouteHandler : DynamicDataRouteHandler
     {
          /// <summary>
          /// Creates the handler.
          /// </summary>
          /// <param name="route">The route.</param>
          /// <param name="table">The table.</param>
          /// <param name="view">The action.</param>
          /// <returns>An IHttpHandler</returns>
          public override IHttpHandler CreateHandler(DynamicDataRoute route, MetaTable table, string view)
          {
               var httpContext = HttpContext.Current;
               if (httpContext != null)
               {
                    string[] usersRoles = new string[] { "Guest" };
                    if (httpContext.User.Identity.Name != "")
                    {
                         usersRoles = Roles.GetRolesForUser(httpContext.User.Identity.Name);
                         if (usersRoles.Length == 0)
                              usersRoles = new string[] { "Guest" };
                    }

                    var tablePermissions = table.Attributes.OfType<DataAccess>();

                    if (tablePermissions.Count() == 0)
                         return null;

                    foreach (var tp in tablePermissions)
                    {
                        if (tp.HasAnyRole(usersRoles))
                        {
                            // if no action is allowed return no route
                            var tpTableView = tp.TableViews.ToString().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            var tpRowView = tp.RowViews.ToString().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (tpTableView.Contains(view))
                                return base.CreateHandler(route, table, view);

                            if (tpRowView.Contains(view))
                                 return base.CreateHandler(route, table, view);
                        }
                    }
               }
               return null;
        }
    }
}

