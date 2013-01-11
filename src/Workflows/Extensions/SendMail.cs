using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Activities;
using System.Net.Mail;

namespace Weavver.Workflows
{
     public class SendMail : CodeActivity<SmtpStatusCode>
     {
          public InArgument<string> To { get; set; }
          public InArgument<string> From { get; set; }
          public InArgument<string> Subject { get; set; }
          public InArgument<string> Body { get; set; }

          protected override SmtpStatusCode Execute(CodeActivityContext context)
          {
               try
               {
                    SmtpClient client = new SmtpClient();
                    client.Host = ConfigurationManager.AppSettings["smtp_server"];
                    client.Send(From.Get(context),
                                   To.Get(context),
                                   Subject.Get(context),
                                   Body.Get(context).Replace("{workflowid}", context.WorkflowInstanceId.ToString()));
               }
               catch (SmtpException smtpEx)
               {
                    return smtpEx.StatusCode;
               }
               return SmtpStatusCode.Ok;
          }
     }
}
