using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.ComponentModel;
using System.Data.Objects.DataClasses;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
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
//-------------------------------------------------------------------------------------------
          public static DataAccess CanListData(this Type typ)
          {
               DataAccess[] atts = (DataAccess[])typ.GetCustomAttributes(true).GetType().GetCustomAttributes(typeof(DataAccess), true);
               foreach (DataAccess da in atts)
               {
                    if (da.Actions == RowAction.Insert)
                    {
                         return da;
                    }
               }

               DataAccess defaultListPermissions = new DataAccess(TableView.List, null);
               defaultListPermissions.AllowedRoles = new string[] { "Administrators" };
               return defaultListPermissions;
          }
//-------------------------------------------------------------------------------------------
          public static DataAccess InsertPermissions(this Type typ)
          {
               DataAccess[] atts = (DataAccess[])typ.GetCustomAttributes(typeof(DataAccess), true);
               foreach (DataAccess da in atts)
               {
                    if (da.Actions == RowAction.Insert)
                    {
                         return da;
                    }
               }

               DataAccess defaultInsertPermissions = new DataAccess(RowAction.Insert, null);
               defaultInsertPermissions.AllowedRoles = new string[] { "Administrators" };
               return defaultInsertPermissions;
          }
//-------------------------------------------------------------------------------------------
          public static DataAccess ReadPermissions(this EntityObject obj)
          {
               DataAccess[] atts = (DataAccess[])obj.GetType().GetCustomAttributes(typeof(DataAccess), true);
               foreach (DataAccess da in atts)
               {
                    if (da.RowViews == RowView.Details)
                    {
                         return da;
                    }
               }
               return null;
          }
//-------------------------------------------------------------------------------------------
          public static DataAccess UpdatePermissions(this EntityObject obj)
          {
               DataAccess[] atts = (DataAccess[])obj.GetType().GetCustomAttributes(typeof(DataAccess), true);
               foreach (DataAccess da in atts)
               {
                    if (da.RowViews == RowView.Edit)
                    {
                         return da;
                    }
               }
               DataAccess defaultUpdatePermissions = new DataAccess(RowAction.Update, null);
               defaultUpdatePermissions.AllowedRoles = new string[] { "Administrators" };
               return defaultUpdatePermissions;
          }
//-------------------------------------------------------------------------------------------
          public static DataAccess DeletePermissions(this EntityObject obj)
          {
               DataAccess[] atts = (DataAccess[])obj.GetType().GetCustomAttributes(typeof(DataAccess), true);
               foreach (DataAccess da in atts)
               {
                    if (da.Actions == RowAction.Delete)
                    {
                         return da;
                    }
               }
               DataAccess defaultDeletePermissions = new DataAccess(RowAction.Delete, null);
               defaultDeletePermissions.AllowedRoles = new string[] { "Administrators" };
               return defaultDeletePermissions;
          }
//-------------------------------------------------------------------------------------------
     }
//-------------------------------------------------------------------------------------------
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
//-------------------------------------------------------------------------------------------
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
//-------------------------------------------------------------------------------------------
}