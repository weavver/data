using System;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Text;

public class RssTemplate
{
     private XmlTextWriter writer;

     public RssTemplate(Stream stream, Encoding encoding)
     {
          writer              = new XmlTextWriter(stream, encoding);
          writer.Formatting   = Formatting.Indented;
     }
     public RssTemplate(TextWriter w)
     {
          writer              = new XmlTextWriter(w);
          writer.Formatting   = Formatting.Indented;
     }

     public void WriteStartDocument()
     {
          writer.WriteStartDocument();
          writer.WriteStartElement("rss");
          writer.WriteAttributeString("version", "2.0");
     }

     public void WriteEndDocument()
     {
          writer.WriteEndElement();
          writer.WriteEndDocument();
     }

     public void Close()
     {
          writer.Flush();
          writer.Close();
     }

     public void WriteStartChannel(string title, string link, string description)
     {
          writer.WriteStartElement("channel");
          writer.WriteElementString("title", title);
          writer.WriteElementString("link", link);
          writer.WriteElementString("description", description);
          writer.WriteElementString("language", "en-us");
          writer.WriteElementString("pubDate", DateTime.Now.ToString("r"));
          writer.WriteElementString("lastBuildDate", DateTime.Now.ToString("r"));
          //writer.WriteElementString("ttl", "20");
     }

     public void WriteEndChannel()
     {
          writer.WriteEndElement();
          writer.Flush();
     }

     public void WriteItem(string title, string author, string link, string description, DateTime publishedDate)
     {
          writer.WriteStartElement("item");
          writer.WriteElementString("title", title);
          writer.WriteElementString("author", author);
          writer.WriteElementString("link", link);
          writer.WriteElementString("description", description);
          writer.WriteElementString("pubDate", publishedDate.ToString("r"));
          writer.WriteEndElement();
     }

     public void WriteImageItem(string ImageUrl, string ImageThumbnailURL, Size ImageSize, string ImageType, string ImageText)
     {
          writer.WriteStartElement("item");
               writer.WriteStartElement("media:content", "");
                    writer.WriteAttributeString("url", ImageUrl);
                    writer.WriteAttributeString("type", ImageType);
                    writer.WriteAttributeString("height", ImageSize.Height.ToString());
                    writer.WriteAttributeString("Width", ImageSize.Width.ToString());
               writer.WriteEndElement();
               writer.WriteStartElement("media:text", ImageText);
                    writer.WriteAttributeString("type", "html");
               writer.WriteEndElement();
          //writer.WriteElementString("pubDate", publishedDate.ToString("r"));
          writer.WriteEndElement();
     }
}