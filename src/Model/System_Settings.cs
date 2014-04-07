using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Configuration;

namespace Weavver.Data
{
//     [MetadataType(typeof(System_Settings.Metadata))]
//     [DisplayName("Settings")]
//     [DataAccess(TableView.Full, "Administrators")]
//     partial class System_Settings : IAuditable
//     {
//          public class Metadata
//          {
//               [ScaffoldColumn(false)]
//               public object Id;

//               [HideColumnIn(PageTemplate.List)]
//               public object CreatedAt;

//               [HideColumnIn(PageTemplate.List)]
//               public object CreatedBy;

//               [HideColumnIn(PageTemplate.List)]
//               public object UpdatedAt;
//          }
//     }

     
     public class GlobalSettings
     {
//-------------------------------------------------------------------------------------------
          public string ActiveDirectory_Server { get; set; }
          public string ActiveDirectory_Username { get; set; }
          public string ActiveDirectory_Password { get; set; }
          public string DBURL
          {
               get
               {
                    return System.Configuration.ConfigurationManager.AppSettings["couchdb_url"];
               }
               set
               {
                    string x = value;
               }
          }
          public string DomainName { get; set; }
          public string SMTPServer { get; set; }
          public string PaymentGateway_URL { get; set; }
          public string PaymentGateway_Username { get; set; }
          public string PaymentGateway_Password { get; set; }
//--------------------------------------------------------------------------------------------
          public static string SMTPHost
          {
               get
               {
                    string smtpserver = ConfigurationManager.AppSettings.Get("smtp_server");
                    if (smtpserver == null)
                    {
                         smtpserver = "192.168.10.11";
                    }
                    return smtpserver;
               }
          }
//--------------------------------------------------------------------------------------------
          public static int SMTPPort
          {
               get
               {
                    int port = 25;
                    Int32.TryParse(ConfigurationManager.AppSettings.Get("smtp_port"), out port);
                    return port;
               }
          }
//--------------------------------------------------------------------------------------------
          public static string AdminAddress
          {
               get
               {
                    return "mythicalbox@weavver.com";
               }
          }
//-------------------------------------------------------------------------------------------
          public GlobalSettings() : base()
          {
          }
//-------------------------------------------------------------------------------------------
     }
}