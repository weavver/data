using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web.DynamicData;
using System.Web.UI.WebControls;
using System.Collections;
using System.Web.UI;
using System.Reflection;
using System.ComponentModel;

namespace Weavver.Data
{
    public static class EnumExtensionMethods
    {
//-------------------------------------------------------------------------------------------
        public static T ToEnum<T>(this String enumString) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumString);
            return (T)value;
        }
//-------------------------------------------------------------------------------------------
        public static T ToEnum<T>(this int enumInt) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumInt.ToString());
            return (T)value;
        }
//-------------------------------------------------------------------------------------------
        public static String ToString<T>(this int enumInt) //where T : Enum
        {
            var value = Enum.Parse(typeof(T), enumInt.ToString()).ToString();
            return value;
        }
//-------------------------------------------------------------------------------------------
        public static T FindControlR<T>(this Control root, string id) where T : Control
        {
             System.Web.UI.Control controlFound;
             if (root != null)
             {
                  controlFound = root.FindControl(id);
                  if (controlFound != null)
                  {
                       return controlFound as T;
                  }
                  foreach (Control c in root.Controls)
                  {
                       controlFound = c.FindControlR<T>(id);
                       if (controlFound != null)
                       {
                            return controlFound as T;
                       }
                  }
             }
             return null;
        }
//-------------------------------------------------------------------------------------------
        public static string DescriptionAttr<T>(this T source)
        {
             FieldInfo fi = source.GetType().GetField(source.ToString());

             DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

             if (attributes != null && attributes.Length > 0)
                  return attributes[0].Description;
             else
                  return source.ToString();
        }
//-------------------------------------------------------------------------------------------
    }
}
