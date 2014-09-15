using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;
using System.Net;
using System.Text;
using System.Collections.Specialized;
using System.IO;
using System.Xml;

public partial class StoredProcedures
{
     [Microsoft.SqlServer.Server.SqlProcedure]
     public static void HttpPost()
     {
          //System.Net.WebClient s = new System.Net.WebClient();
          //string data = s.DownloadString("http://www.weavver.com/system/tests/postbacktest.aspx");
          ////return 1;
          //////return data;
          using (SqlConnection connection = new SqlConnection("context connection=true"))
          {
               connection.Open();
               SqlCommand receiveCommand = connection.CreateCommand();
               SqlTransaction trans = connection.BeginTransaction();
               receiveCommand.Transaction = trans;
               receiveCommand.CommandText = "RECEIVE TOP(1) CONVERT(NVARCHAR(MAX), message_body), conversation_handle FROM dbo.SBReceiveQueue";
               using (SqlDataReader reader = receiveCommand.ExecuteReader())
               {
                    if (reader.Read())
                    {
                         SqlString messageBody = reader.GetString(0);
                         Guid conversationHandle = reader.GetGuid(1);

                         XmlDocument doc = new XmlDocument();
                         doc.LoadXml(messageBody.Value);


                         string relayTo = doc.SelectSingleNode("/WebBusMessage/relayTo").InnerText;
                         XmlNode responseNode = doc.SelectSingleNode("/WebBusMessage/relayResponseTo");
                         string relayResponseTo = null;
                         if (responseNode != null)
                              relayResponseTo = doc.SelectSingleNode("/WebBusMessage/relayResponseTo").InnerText;
                         string postData = doc.SelectSingleNode("/WebBusMessage/postData").InnerText;

                         NameValueCollection nvc = new NameValueCollection();
                         using (WebClient wc = new WebClient())
                         {
                              wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                              //byte[] HtmlResult = wc.UploadValues(URI, nvc);

                              wc.Encoding = System.Text.Encoding.UTF8;
                              string x = messageBody.Value;
                              try
                              {
                                   wc.UploadString(relayTo, "POST", postData);
                              }
                              catch (WebException ex)
                              {
                                   HttpWebResponse response = (System.Net.HttpWebResponse)ex.Response;
                                   nvc.Add("webbus_http_statuscode", ((int)response.StatusCode).ToString());
                                   nvc.Add("webbus_http_statusdescription", response.StatusDescription);
                                   nvc.Add("webbus_error_message", ex.Message);
                                   using (StreamReader reader2 = new StreamReader(response.GetResponseStream()))
                                   {
                                        string html = reader2.ReadToEnd();
                                        if (html.Length > 5)
                                             nvc.Add("html", html.Substring(0, 5));
                                   }
                                   wc.UploadValues(relayResponseTo, nvc);
                              }
                              catch (Exception ex)
                              {
                                   nvc.Add("error_message", ex.Message);
                                   wc.UploadValues(relayResponseTo, nvc);
                              }
                         }
                    }
               }

               trans.Commit();
               connection.Close();
          }
     }
};
