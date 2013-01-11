using System;
using System.Linq;
using System.Web.DynamicData;

namespace Weavver.Data
{
     /// <summary>
     /// attribute to suppress an MetaChildColumn or MetaParetnColumn in the 
     /// filter repeater
     /// </summary>
     [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
     public class HideInFilterAttribute : System.Attribute
     {
          // this property is required to work with "AllowMultiple = true" ref David Ebbo
          // As implemented, this identifier is merely the Type of the attribute. However, 
          // it is intended that the unique identifier be used to identify two 
          // attributes of the same type.
          public override object TypeId { get { return this; } }

          /// <summary>
          /// Constructor
          /// </summary>
          public HideInFilterAttribute()
          {
          }
     }

     /// <summary>
     /// Permissions Attributes Helper Extension Methods
     /// </summary>
     public static class HideInFilterAttributesHelper
     {
          public static Boolean ContainsHideInFilter(this MetaColumn column)
          {
               // thanks to Marcin Dobosz for this really elegant code
               return column.Attributes.OfType<HideInFilterAttribute>().FirstOrDefault() != null;
          }
     }
}