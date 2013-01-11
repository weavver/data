using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using System.ServiceModel.Syndication;
using System.Net;
using System.Xml;

namespace Weavver.Workflows
{
     public sealed class GetFeed : AsyncCodeActivity<SyndicationFeed>
     {
          public InArgument<Uri> FeedUrl { get; set; }
          protected override IAsyncResult BeginExecute(
//-------------------------------------------------------------------------------------------
          AsyncCodeActivityContext context, AsyncCallback callback, object state)
          {
               var req = (HttpWebRequest)HttpWebRequest.Create(FeedUrl.Get(context));
               req.Method = "GET";
               context.UserState = req;
               return req.BeginGetResponse(new AsyncCallback(callback), state);
          }
//-------------------------------------------------------------------------------------------
          protected override SyndicationFeed EndExecute(AsyncCodeActivityContext context, IAsyncResult result)
          {
               HttpWebRequest req = context.UserState as HttpWebRequest;
               WebResponse wr = req.EndGetResponse(result);
               SyndicationFeed localFeed = SyndicationFeed.Load(
               XmlReader.Create(wr.GetResponseStream()));
               return localFeed;
          }
//-------------------------------------------------------------------------------------------
     }
}
