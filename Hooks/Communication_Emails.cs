using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

namespace Weavver.Hooks
{
     public partial class Communication_Emails : IWeavverEntityContainerExtender
     {
//          public void OnSave()
//          {

//               //Employee emp = DatabaseHelper.Session.Get<Weavver.Company.HumanResources.Employee>(item.AssignedTo.ToString());
//               //MailMessage msg = new System.Net.Mail.MailMessage(DatabaseHelper.GetName(LoggedInUser.Id) + " <issues@weavver.com>", emp.EmailAddress);
//               //msg.Subject = "Comment on issue \"" + item.Subject + "\"";
//               //string body = "Comment from " + DatabaseHelper.GetName(LoggedInUser.Id) + "\r\n\r\n" + ReplyBody.Text + GetFooter();
//               //msg.Body = body;
//////-------------------------------------------------------------------------------------------
//               //     public string GetFooter()
//               //     {
//               //          return "--------------------\r\nPlease do not reply to this e-mail. Instead visit http://www.weavver.local/company/support/issue.aspx?id=" + item.Id;
//               //     }
//          }

          public void OnContextCreated(WeavverEntityContainer container)
          {
               
          }
     }
}
