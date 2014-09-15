using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenPop.Pop3;
using OpenPop.Mime;

using Weavver.Data;
using Weavver.Utilities;

namespace Weavver.Data
{
     public partial class Communication_Messages_Import : ICRON
     {
//-------------------------------------------------------------------------------------------
          public void RunCronTasks(CommandLineArguments args)
          {
               return;
               using (WeavverEntityContainer entity = new WeavverEntityContainer())
               {
                    var accounts = from x in entity.Communication_EmailAccounts
                                   select x;

                    accounts.ToList().ForEach(account => ImportEmails(account));
               }
          }
//-------------------------------------------------------------------------------------------
          private void ImportEmails(Communication_EmailAccounts account)
          {
               using (Pop3Client client = new Pop3Client())
               {
                    // connect
                    client.Connect(account.Host, account.Port, (account.Type == "pops"));
                    client.Authenticate(account.Username, account.Password);

                    // iterate over the messages
                    int messageCount = client.GetMessageCount();
                    List<Message> allMessages = new List<Message>(messageCount);
                    for (int i = 1; i <= messageCount; i++)
                    {
                         using (WeavverEntityContainer data = new WeavverEntityContainer())
                         {
                              //data.SearchAllTables("asdf");
                              // save to database
                              Message m = (Message) client.GetMessage(i);
                              if (m.MessagePart.IsText)
                              {
                                   Communication_Emails item = new Communication_Emails();
                                   item.From = m.Headers.From.Raw;
                                   item.Subject = m.Headers.Subject;
                                   item.Raw = System.Text.ASCIIEncoding.ASCII.GetString(m.RawMessage);
                                   data.SaveChanges();

                                   client.DeleteMessage(i);
                              }
                         }
                    }
               }
          }
//-------------------------------------------------------------------------------------------
     }
}
