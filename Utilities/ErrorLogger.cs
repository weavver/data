using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using Weavver.Vendors.ProcessOne;
using Weavver.Data;

namespace Weavver.Utilities
{
     public class ErrorHandling
     {
          public static string LogError(HttpRequest request, string errorurl, Exception error)
          {
               if (ConfigurationManager.AppSettings["install_mode"] == "false")
               {
                    string errorlog = "Error caught in Application_Error event on " +
                                 "page <a href='" + errorurl + "'>" + errorurl + "</a>\r\n\r\n";

                    errorlog += error.ToString();

                    if (error.Message != null)
                         errorlog += "Message: " + error.Message.ToString() + "\r\n\r\n";
                    if (error.StackTrace != null)
                         errorlog += "Stack Trace: " + error.StackTrace.ToString();

                    errorlog += "Raw URL: " + request.RawUrl + "?" + request.QueryString.ToString() + "\r\n";
                    errorlog += "Form: " + request.Form.ToString() + "\r\n";
                    

                    if (request != null)
                    {
                         errorlog += "UserHostAddress: " + request.UserHostAddress + "\r\n";
                         errorlog += "Referral URL: " + request["ReferralUrl"] + "\r\n";
                         errorlog += "User Agent: " + request.UserAgent + "\r\n\r\n";
                    }
                    for (int i = 0; i < request.Form.Keys.Count; i++)
                    {
                         errorlog += request.Form.Keys[i] + ": " + request.Form[request.Form.Keys[i]] + "\r\n";
                    }
                    for (int i = 0; i < request.Files.Count; i++)
                    {
                         errorlog += "\r\nFile '" + request.Files[i].FileName + "' of type " + request.Files[i].ContentType + " was in the posted data.\r\n\r\n";
                    }

                    MailMessage msg = new MailMessage("system@weavver.com", ConfigurationManager.AppSettings["admin_address"]);
                    msg.Subject = "Weavver System - Website Error";
                    msg.Body = errorlog;

                    SmtpClient sClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"], Int32.Parse(ConfigurationManager.AppSettings["smtp_port"]));
                    sClient.Send(msg);

                    send_message_chat message = new send_message_chat();
                    message.from = "weavver.com";
                    message.to = GlobalSettings.AdminAddress;
                    message.body = msg.Body;
                    ejabberdRPC rpc = new ejabberdRPC();
                    //rpc.SendMessageChat(message);
                    return errorlog;
               }
               return "Install mode is on. Please check that.";
          }

          public static void SendError(Exception e)
          {
               MailMessage message = new MailMessage("voicescribe@weavver.com", "mitchel@weavver.com");
               SmtpClient client = new SmtpClient("192.168.10.11");

               message.Subject = "Unhandled exception";
               message.Body = "Message:\r\n" + e.Message + "\r\n\r\nStack Trace:\r\n" + e.StackTrace + "\r\n\r\n" + e.ToString();
               client.Send(message);
          }
     }
}