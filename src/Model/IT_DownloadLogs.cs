using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(IT_DownloadLogs.Metadata))]
     [DisplayName("Download Logs")]
     [DisplayColumn("FileName", "DownloadedAt", true)]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
     partial class IT_DownloadLogs
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [Display(Name = "File Name")]
               public object FileName;

               [Display(Name = "Downloaded At")]
               public object DownloadedAt;

               [Display(Name = "Downloaded By IP")]
               public object DownloadedByIP;

               [Display(Name="Downloaded By")]
               public object System_Users;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Geo-locate the IP", "IT Staff")]
          public DynamicDataWebMethodReturnType GeoLocatetheIP()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = "http://www.maxmind.com/app/locate_demo_ip?ips=" + DownloadedByIP;
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}