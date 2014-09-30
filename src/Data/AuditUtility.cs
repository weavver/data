using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Configuration;
using System.Data.Entity.Infrastructure;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     public static class AuditUtility
     {
//-------------------------------------------------------------------------------------------
          public static Guid GetOrganizationId()
          {
               var context = System.Web.HttpContext.Current;
               if (context != null && context.Session["SelectedOrganizationId"] != null)
               {
                    Guid selOrgId = Guid.Empty;
                    if (Guid.TryParse(context.Session["SelectedOrganizationId"].ToString(), out selOrgId))
                    {
                         return selOrgId;
                    }
               }
               else if (ConfigurationManager.AppSettings["mode"] == "testing")
               {
                    return new Guid(ConfigurationManager.AppSettings["SelectedOrganizationId"]);
               }
               throw new Exception("Unable to find the selected organization id.");
          }
//-------------------------------------------------------------------------------------------
          public static Guid GetUserId()
          {
               //(LoggedInUser == null) ? Guid.Empty : LoggedInUser.Id;
               var context = System.Web.HttpContext.Current;
               if (context == null || !context.User.Identity.IsAuthenticated)
                    return Guid.Empty;

               var user = Membership.GetUser(context.User.Identity.Name);
               var guid = new Guid(user.ProviderUserKey.ToString());
               return guid;
          }
//-------------------------------------------------------------------------------------------
          public static void ProcessAuditFields(IEnumerable<DbEntityEntry> list, bool InsertMode = true)
          {
               foreach (DbEntityEntry item in list)
               {
                    var entity = item.Entity as IAuditable;
                    if (entity != null)
                    {
                         // deal with insert and update entities
                         var auditEntity = item.Entity as IAuditable;
                         if (auditEntity != null)
                         {
                              UpdateAuditFields(auditEntity, InsertMode);
                         }
                    }

                    var validator = item.Entity as IValidator;
                    if (validator != null)
                    {
                         bool isValid = false;
                         string errorMessage = "";
                         validator.Validate(out isValid, out errorMessage);
                         if (!isValid)
                         {
                              throw new IValidatorException(errorMessage);
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public static void UpdateAuditFields(IAuditable auditEntity, bool InsertMode = true)
          {
               var appUserID = GetUserId();
               if (InsertMode)
               {
                    if (auditEntity.Id == Guid.Empty)
                         auditEntity.Id = Guid.NewGuid(); // alternative method: http://leedumond.com/blog/using-a-guid-as-an-entitykey-in-entity-framework-4/
                    //  or [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // http://stackoverflow.com/questions/5270721/using-guid-as-pk-with-ef4-code-first
                    // auditEntity.OrganizationId = Session["OrganizationId"] = HttpContext.Current.Session["SelectedOrganizationId"];

                    // we do this to enforce security so data can't be inserted into an organization that we are not associated with
                    // -- warning this is currently buggy and disabled it's changing system_user row's organizationid to organizations that they do not belong to
                    //auditEntity.OrganizationId = GetOrganizationId();
                    auditEntity.CreatedAt = DateTime.Now.ToUniversalTime();

                    if (auditEntity.CreatedBy == Guid.Empty)
                    {
                         auditEntity.CreatedBy = appUserID;
                    }
               }
               auditEntity.UpdatedAt = DateTime.Now.ToUniversalTime();
               if (auditEntity.UpdatedBy == Guid.Empty)
               {
                    auditEntity.UpdatedBy = appUserID;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
