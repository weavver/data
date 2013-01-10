using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Data;
using System.Net.Mail;
using Weavver.Hooks;
using System.Configuration;
using System.Web;

namespace Weavver.Data
{
     partial class Communication_Messages : IDatabaseHook
     {
          public void OnSave()
          {
               // E-mail the object creator -- Easily accessible via CreatedBy
               // E-mail anyone in the conversation thread // Except the Creator of the Message
               // E-mail person that wrote the message -- NOT

               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var createdByUser = (from x in data.System_Users
                                         where x.Id == CreatedBy
                                         select x).First();

                    List<Guid> listeners = new List<Guid>();

                    MailMessage msg = new MailMessage("Weavver <comments@weavver.com>", createdByUser.EmailAddress);

                    var comments = (from y in data.Communication_Messages
                                    where y.Account == Account
                                    select y);

                    foreach (var comment in comments)
                    {
                         if (!listeners.Contains(comment.CreatedBy))
                         {
                              listeners.Add(comment.CreatedBy);

                              var user = (from x in data.System_Users
                                          where x.Id == comment.CreatedBy
                                          select x).First();
                              msg.To.Add(new MailAddress(user.EmailAddress, user.FullName));
                         }
                    }

                    msg.Subject = createdByUser.FullName + " made a comment"; // on \"" + this.GetType().Name + "\"";
                    string body = "\"" + Body + "\"\r\n\r\n"
                                + "Reply via the following url:\r\n" + HttpContext.Current.Request.Url + "\r\n\r\n"
                                + "------------------------\r\nWeavver, Inc.";
                    msg.Body = body;

                    SmtpClient sClient = new System.Net.Mail.SmtpClient(ConfigurationManager.AppSettings["smtp_address"]);
                    sClient.Send(msg);
               }
          }
     }
}