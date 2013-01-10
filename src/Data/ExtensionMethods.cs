using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.ComponentModel;

namespace Weavver.Data
{
     public static class ControlExtensionMethods
     {
          // "~/DynamicData/PageTemplates/List.aspx"
          private const String extension = ".aspx";

          /// <summary>
          /// Gets the page template from the page.
          /// </summary>
          /// <param name="page">The page.</param>
          /// <returns></returns>
          public static PageTemplate GetPageTemplate(this Page page)
          {
               try
               {
                    return (PageTemplate)Enum.Parse(typeof(PageTemplate),
                        page.RouteData.Values["action"].ToString());
               }
               catch (ArgumentException)
               {
                    return PageTemplate.Unknown;
               }
          }
     }

     [Flags]
     public enum PageTemplate
     {
          // standard page templates
          Details = 0x01,
          Edit = 0x02,
          Insert = 0x04,
          List = 0x08,
          ListDetails = 0x10,
          // unknown page templates
          Unknown = 0xff,
     }
     public static class EntityDataSourceExtensions
     {
          public static TEntity GetItemObject<TEntity>(object dataItem)
              where TEntity : class
          {
               var entity = dataItem as TEntity;
               if (entity != null)
               {
                    return entity;
               }
               var td = dataItem as ICustomTypeDescriptor;
               if (td != null)
               {
                    return (TEntity)td.GetPropertyOwner(null);
               }
               return null;
          }
     }
}