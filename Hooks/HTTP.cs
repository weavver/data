using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Weavver.Hooks
{
     public class HTTPDatabaseHook : IDatabaseHook
     {
//--------------------------------------------------------------------------------------------
          // pushes the object to a remote web page that subscribed to changes or receives
          public void OnSave()
          {
              // Console.WriteLine(" -- tracking object to: " + url);
              // string         strPost   = "";
              // if (fileid != Guid.Empty)
              //      strPost += "fileid=" + HttpUtility.UrlEncode(fileid.ToString()) + "&";
              // strPost                 += postString;
              // string         result    = "";
              // StreamWriter   myWriter  = null;
              // HttpWebRequest wClient   = (HttpWebRequest) WebRequest.Create(url);
              // wClient.Method           = "POST";
              // wClient.ContentType      = "application/x-www-form-urlencoded";
              // wClient.ContentLength    = strPost.Length;
              // try
              // {
              //      myWriter = new StreamWriter(wClient.GetRequestStream());
              //      myWriter.Write(strPost);
              // }
              // catch (Exception e) 
              // {
              //      Console.WriteLine(e.Message);
              // }
              // finally
              // {
              //      myWriter.Close();
              // }
              // HttpWebResponse objResponse = (HttpWebResponse) wClient.GetResponse();
              // using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()) )
              // {
              //      result = sr.ReadToEnd();
              //      // Close and clean up the StreamReader
              //      sr.Close();
              // }
              // if (result.Contains("OK"))
              // {
              //      return true;
              // }
              // else
              // {
              //      return false;
              // }
          }
//--------------------------------------------------------------------------------------------
     }
}
