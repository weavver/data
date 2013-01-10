using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;

using Weavver.Vendors.ProcessOne;
using System.IO;

namespace Weavver.Utilities
{
     public class Common
     {
//-------------------------------------------------------------------------------------------
          public static readonly DateTime JAN_01_1970 = DateTime.SpecifyKind(new DateTime(1970, 1, 1, 0, 0, 0), DateTimeKind.Utc);
//-------------------------------------------------------------------------------------------
          public static void Log(string subject, string message)
          {
               MailMessage msg          = new MailMessage();
               msg.From                 = new MailAddress("system@weavver.com", "Weavver");
               msg.Subject              = subject;
               msg.Priority             = MailPriority.Normal;
               msg.IsBodyHtml           = true;

               SmtpClient smtpclient    = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"]);
               msg.Priority	          = MailPriority.Normal;
               msg.IsBodyHtml           = false;
               msg.Bcc.Add(ConfigurationManager.AppSettings["admin_address"]);
               msg.Body                 = message;
               smtpclient.Send(msg);
          }
//-------------------------------------------------------------------------------------------
          public static void SetConfigSetting(string configPath, string settingName, string settingValue)
          {
               ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
               configMap.ExeConfigFilename = configPath;
               Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
               //config.AppSettings.Settings.Remove("testchange");

               if (config.AppSettings.Settings[settingName] == null)
                    config.AppSettings.Settings.Add(settingName, settingValue);
               else
                    config.AppSettings.Settings[settingName].Value = settingValue;
               config.Save(ConfigurationSaveMode.Modified);
          }
//-------------------------------------------------------------------------------------------
          public static string FormatPhoneNumber(Int64 number)
          {
               if (number.ToString().Length == 7)
                    return String.Format("{0:###-####}", number);
               else if (number.ToString().Length == 10)
                    return String.Format("{0:(###) ###-####}", number);
               else if (number.ToString().Length == 11)
                    return String.Format("{0:# (###) ###-####}", number);
               return number.ToString();
          }
//-------------------------------------------------------------------------------------------
          public static string StripHTML(string html)
          {
               return Regex.Replace(html, @"<(.|\n)*?>", string.Empty);
          }
//-------------------------------------------------------------------------------------------
          public static void CopyFolder(string sourceFolder, string destFolder)  
          {  
               if (!Directory.Exists(destFolder))  
                    Directory.CreateDirectory(destFolder);  
               string[] files = Directory.GetFiles(sourceFolder);  
               foreach (string file in files)  
               {  
                    string name = Path.GetFileName(file);  
                    string dest = Path.Combine(destFolder, name);  
                    File.Copy(file, dest, true);  
               }  
               string[] folders = Directory.GetDirectories(sourceFolder);  
               foreach (string folder in folders)  
               {  
                    string name = Path.GetFileName(folder);  
                    string dest = Path.Combine(destFolder, name);  
                    CopyFolder(folder, dest);  
               }
          }
//-------------------------------------------------------------------------------------------
          private static void LogToXMPP(string subject, string body)
          {
               //try
               //{
               //     send_message_chat message = new send_message_chat();
               //     message.from = "weavver.com";
               //     message.body = body;
               //     message.to = ConfigurationManager.AppSettings["admin_address"];
               //     ejabberdRPC rpc = new ejabberdRPC();
               //     rpc.SendMessageChat(message);
               //}
               //catch (Exception ex)
               //{
               //     Log("Error in LogToXMPP", ex.ToString() + "\r\n\r\n" + body);
               //}
          }
//-------------------------------------------------------------------------------------------
		public static bool IsValidAddress(string address)
		{
               if (String.IsNullOrEmpty(address))
                    return false;
               if (address.IndexOf("@") <= 0 || address.IndexOf(".") <= 0)
				return false;
			else
				return true;
		}
//-------------------------------------------------------------------------------------------
          public static bool Windows
          {
               get
               {
                    return Environment.OSVersion.Platform.ToString().StartsWith("Win32");
               }
          }
//-------------------------------------------------------------------------------------------
          public static Boolean GuidTryParse(string s, out Guid value)
          {
               try
               {
                    value = new Guid(s);
                    return true;
               }
               catch (FormatException)
               {
                    value = Guid.Empty;
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          public static string SplitCombinedWord(string word)
          {
               string formattedword = "";
               bool insertspace = false;
               for (int i = 0; i < word.Length; i++)
               {
                    // if this character is upper case
                    if (word[i].ToString() == word[i].ToString().ToUpper())
                    {
                         if (insertspace)
                         {
                              formattedword += " ";
                         }
                         insertspace = true;
                         formattedword += word[i].ToString();
                    }
                    else
                    {
                         formattedword += word[i];
                    }
               }
               return formattedword;
          }
//-------------------------------------------------------------------------------------------
          public static string MD5(string cleartext)
          {
               System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
               byte[] raw = System.Text.ASCIIEncoding.ASCII.GetBytes(cleartext);
               byte[] hash = md5.ComputeHash(raw);
               return BitConverter.ToString(hash).Replace("-", "");
          }
//-------------------------------------------------------------------------------------------
     }
}