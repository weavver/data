using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Web.Security;

using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;
using System.Reflection;
using System.Net.Mail;
using System.Configuration;
using System.Data.SqlTypes;
using System.IO;
using Weavver.Hooks;

namespace Weavver.Data
{
     public partial class WeavverEntityContainer : ObjectContext
     {
//-------------------------------------------------------------------------------------------
          partial void OnContextCreated()
          {
               var type = typeof(IWeavverEntityContainerExtender);
               //// Keep this empty foreach block to help with debugging type loader errors
               foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
               {
                    try
                    {
                         foreach (Type t in ass.GetTypes())
                         {
                              if (type.IsAssignableFrom(t) && t.IsClass)
                              {
                                   object o = Activator.CreateInstance(t);
                                   var weavverEntityContainerExtender = o as IWeavverEntityContainerExtender;
                                   weavverEntityContainerExtender.OnContextCreated(this);
                              }
                         }
                    }
                    catch (Exception ex)
                    {
                    }
               }

               //var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
               //    .SelectMany(s => s.GetTypes())
               //    .Where(p => type.IsAssignableFrom(p) && p.IsClass);

               //foreach (var interfacedClassType in types)
               //{
               //     object o = Activator.CreateInstance(interfacedClassType);
               //     var weavverEntityContainerExtender = o as IWeavverEntityContainerExtender;
               //     weavverEntityContainerExtender.OnContextCreated(this);
               //}
               this.SavingChanges += new EventHandler(ObjectContext_SavingChanges);
          }
//-------------------------------------------------------------------------------------------
          [EdmFunction("weavverstagingModel.Store", "GetName")]
          public string GetName(Guid id)
          {
               return this.QueryProvider.Execute<string>(Expression.Call(
                      Expression.Constant(this),
                      (MethodInfo) MethodInfo.GetCurrentMethod(),
                      Expression.Constant(id, typeof(Guid))));
          }
//-------------------------------------------------------------------------------------------
          [EdmFunction("weavverstagingModel.Store", "Total_ForLedger")]
          public decimal Total_ForLedger(Guid organizationId,
                                         Guid accountId,
                                         string ledgerType,
                                         bool includeCredits,
                                         bool includeDebits,
                                         bool includeReservedFunds,
                                         DateTime? startAt,
                                         DateTime? endAt)
          {
               return this.QueryProvider.Execute<decimal>(Expression.Call(
                      Expression.Constant(this),
                      (MethodInfo)MethodInfo.GetCurrentMethod(),
                      Expression.Constant(organizationId, typeof(Guid)),
                      Expression.Constant(accountId, typeof(Guid)),
                      Expression.Constant(ledgerType, typeof(string)),
                      Expression.Constant(includeCredits, typeof(bool)),
                      Expression.Constant(includeDebits, typeof(bool)),
                      Expression.Constant(includeReservedFunds, typeof(bool)),
                      Expression.Constant(startAt.HasValue ? startAt : null, typeof(DateTime?)),
                      Expression.Constant(endAt.HasValue ? endAt : null, typeof(DateTime?))
                      ));
          }
//-------------------------------------------------------------------------------------------
          private static void ObjectContext_SavingChanges(object sender, EventArgs e)
          {
               var objects = ((ObjectContext)sender).ObjectStateManager;

               IEnumerable<ObjectStateEntry> addedObjects = objects.GetObjectStateEntries(EntityState.Added);
               IEnumerable<ObjectStateEntry> modifiedObjects = objects.GetObjectStateEntries(EntityState.Modified);
               IEnumerable<ObjectStateEntry> deletedObjects = objects.GetObjectStateEntries(EntityState.Deleted);

               AuditUtility.ProcessAuditFields(addedObjects);
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
          }
//-------------------------------------------------------------------------------------------
          private static string GetLogItems(IEnumerable<ObjectStateEntry> entries)
          {
               string log = "";
               foreach (ObjectStateEntry entry in entries)
               {
                    string typename = entry.Entity.GetType().ToString().Replace("Weavver.Data.", "");
                    var entity = entry.Entity as IAuditable;
                    if (entity != null)
                         log += String.Format("<a href='http://www.weavver.com/{0}/Details.aspx?Id={1}'>{0}</a>", typename, entity.Id.ToString());
               }
               return log;
          }
//-------------------------------------------------------------------------------------------
          public override int SaveChanges(System.Data.Objects.SaveOptions options)
          {
               var objects = ObjectStateManager.GetObjectStateEntries(EntityState.Added);
               int ret = base.SaveChanges(options);

               Type t = typeof(IDatabaseHook);
               foreach (var obj in objects)
               {
                    Type entityType = obj.Entity.GetType();
                    if (t.IsAssignableFrom(entityType) && entityType.IsClass)
                    {
                         IDatabaseHook hook = (IDatabaseHook) obj.Entity;
                         hook.OnSave();
                    }
               }
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}
