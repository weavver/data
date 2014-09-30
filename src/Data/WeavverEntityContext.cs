using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Core.Objects;
using System.Data;
using System.Web.Security;

using System.Linq.Expressions;
using System.Reflection;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using Weavver.Hooks;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace Weavver.Data
{
     public partial class WeavverEntityContainer : DbContext
     {
//-------------------------------------------------------------------------------------------
//          //partial void OnContextCreated()
//          {
//               var type = typeof(IWeavverEntityContainerExtender);
//               //// Keep this empty foreach block to help with debugging type loader errors
//               //foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
//               //{
//               //     try
//               //     {
//               //          foreach (Type t in ass.GetTypes())
//               //          {
//               //               if (type.IsAssignableFrom(t) && t.IsClass)
//               //               {
//               //                    object o = Activator.CreateInstance(t);
//               //                    var weavverEntityContainerExtender = o as IWeavverEntityContainerExtender;
//               //                    weavverEntityContainerExtender.OnContextCreated(this);
//               //               }
//               //          }
//               //     }
//               //     catch (Exception ex)
//               //     {
//               //     }
//               //}

//               //var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
//               //    .SelectMany(s => s.GetTypes())
//               //    .Where(p => type.IsAssignableFrom(p) && p.IsClass);

//               //foreach (var interfacedClassType in types)
//               //{
//               //     object o = Activator.CreateInstance(interfacedClassType);
//               //     var weavverEntityContainerExtender = o as IWeavverEntityContainerExtender;
//               //     weavverEntityContainerExtender.OnContextCreated(this);
//               //}
////               this.SavingChanges += new EventHandler(ObjectContext_SavingChanges);
//          }
//-------------------------------------------------------------------------------------------
          [DbFunction("WeavverEntityContainer.Store", "GetName")]
          public string GetName(Guid id)
          {
               var idParam = new SqlParameter("id", id);
               var objectName = new SqlParameter("objectName", SqlDbType.VarChar);
               objectName.Direction = ParameterDirection.Output;
               objectName.Size = 255;
               this.Database.ExecuteSqlCommand("exec @objectName = GetName @id", idParam, objectName);
               
               return (string) objectName.Value;
               //return this.Database.ExecuteSqlCommand("exec GetName @id, @objectName OUT", idParam);
          }
//-------------------------------------------------------------------------------------------
          [DbFunction("WeavverEntityContainer.Store", "Total_ForLedger")]
          public decimal Total_ForLedger(Guid organizationId,
                                         Guid accountId,
                                         string ledgerType,
                                         bool includeCredits,
                                         bool includeDebits,
                                         bool includeReservedFunds,
                                         DateTime? startAt,
                                         DateTime? endAt)
          {
               var totalOut = new SqlParameter("outTotal", SqlDbType.Decimal)
               {
                    Direction = System.Data.ParameterDirection.Output
               };

               this.Database.ExecuteSqlCommand("exec @outTotal = Total_ForLedger @organizationId, @accountId, @ledgerType, @includeCredits, @includeDebits, @includeReservedFunds, @startAt, @endAt",
                         new SqlParameter("OrganizationId", organizationId),
                         new SqlParameter("accountId", accountId),
                         new SqlParameter("ledgerType", ledgerType),
                         new SqlParameter("includeCredits", includeCredits),
                         new SqlParameter("includeDebits", includeDebits),
                         new SqlParameter("includeReservedFunds", includeReservedFunds),
                         new SqlParameter("startAt", startAt.HasValue ? (object) startAt.Value : DBNull.Value),
                         new SqlParameter("endAt", endAt.HasValue ? (object) endAt.Value : DBNull.Value),
                         totalOut);

               return (decimal)totalOut.Value;
          }
//-------------------------------------------------------------------------------------------
          private static void ObjectContext_SavingChanges(object sender, EventArgs e)
          {
          }
//-------------------------------------------------------------------------------------------
          private static string GetLogItems(IEnumerable<DbEntityEntry> entries)
          {
               string log = "";
               foreach (var entry in entries)
               {
                    string typename = entry.Entity.GetType().ToString().Replace("Weavver.Data.", "");
                    var entity = entry.Entity as IAuditable;
                    if (entity != null)
                         log += String.Format("<a href='http://www.weavver.com/{0}/Details.aspx?Id={1}'>{0}</a>", typename, entity.Id.ToString());
               }
               return log;
          }
//-------------------------------------------------------------------------------------------
          protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
          {
               return base.ValidateEntity(entityEntry, items);
          }
//-------------------------------------------------------------------------------------------
          public override int SaveChanges()
          {
               ChangeTracker.DetectChanges();
               var objects = ChangeTracker.Entries();
               
               var addedObjects = objects.Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));
               var modifiedObjects = objects.Where(x => x.Entity is IAuditable && (x.State == EntityState.Modified));
               var deletedObjects = objects.Where(x => x.Entity is IAuditable && (x.State == EntityState.Deleted));

               AuditUtility.ProcessAuditFields(addedObjects, InsertMode: true);
               AuditUtility.ProcessAuditFields(modifiedObjects, InsertMode: false);

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Communication_MessageTemplates template = (from x in data.Communication_MessageTemplates
                                                               where x.Name == "Data_ChangeLog"
                                                               select x).FirstOrDefault();

                    if (template != null)
                    {
                         string changeLogSubject = template.Subject;
                         string changeLogBody = template.Body.Replace("[addedobjects]", GetLogItems(addedObjects))
                                                             .Replace("[modifiedobjects]", GetLogItems(modifiedObjects))
                                                             .Replace("[deletedobjects]", GetLogItems(deletedObjects));

                         MailMessage message = new MailMessage("Weavver <therobots@weavver.com>", ConfigurationManager.AppSettings["audit_address"]);

                         var context = System.Web.HttpContext.Current;
                         if (context != null)
                         {
                              var user = Membership.GetUser(context.User.Identity.Name);
                              string username = (user != null) ? user.UserName : "anonymous";
                              message.Subject = changeLogSubject.Replace("[user]", username);
                         }
                         else
                         {
                              message.Subject = changeLogSubject.Replace("[user]", "Session_End");
                         }
                         message.Body = changeLogBody;
                         message.IsBodyHtml = true;
                         SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_address"]);
                         smtpClient.Send(message);
                    }
               }


               

               //foreach (var entity in objects)
               //{
               //     if (entity.State == EntityState.Added)
               //     {
               //          ((IAuditable)entity.Entity).CreatedAt = DateTime.Now;
               //     }

               //     ((IAuditable)entity.Entity).UpdatedAt = DateTime.Now;
               //}
               
               return base.SaveChanges();

               //Type t = typeof(IDatabaseHook);
               //foreach (var obj in objects)
               //{
               //     Type entityType = obj.Entity.GetType();
               //     if (t.IsAssignableFrom(entityType) && entityType.IsClass)
               //     {
               //          IDatabaseHook hook = (IDatabaseHook)obj.Entity;
               //          hook.OnSave();
               //     }
               //}
               //return ret;
          }
//-------------------------------------------------------------------------------------------
          public override System.Threading.Tasks.Task<int> SaveChangesAsync()
          {
               return base.SaveChangesAsync();
          }
//-------------------------------------------------------------------------------------------
     }
}
