using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace Weavver.Exports
{
     public static class XML
     {
          public static string ToXML(this object obj)
          {
               XmlSerializer serializer = new XmlSerializer(obj.GetType());
               StringWriter stringWriter = new StringWriter();
               serializer.Serialize(stringWriter, obj);

               return stringWriter.ToString();
          }
     }
}
