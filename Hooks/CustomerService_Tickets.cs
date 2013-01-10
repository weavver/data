using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Data;

namespace Weavver.Hooks
{
     public partial class CustomerService_Tickets : IDatabaseHook
     {
          public void OnSave()
          {
               //Weavver.Company.HumanResources.Employee emp = DatabaseHelper.Session.Get<Weavver.Company.HumanResources.Employee>(item.AssignedTo.ToString());
               //MailMessage msg = new System.Net.Mail.MailMessage(DatabaseHelper.GetName(LoggedInUser.Id) + " <issues@weavver.com>", emp.EmailAddress);
               //msg.Subject = "New issue: " + item.Subject;

               //if (!newIssue)
               //{
               //     msg.Subject = "Updated issue \"" + item.Subject + "\""; // by " + GetName(PersonId);
               //}
               //string body = String.Format("The following issue was created by {0} and was assigned to you by {1}:\r\n\r\n", DatabaseHelper.GetName(new Guid(item.CreatedBy.ToString())), DatabaseHelper.GetName(new Guid(item.AssignedBy.ToString())));
               //body += item.Message + "\r\n\r\n";
               //body += GetFooter();
               //msg.Body = body;
          }
     }
}
