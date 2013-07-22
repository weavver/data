using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
     public class DataAccess : System.Attribute
     {
          // this property is required to work with "AllowMultiple = true" ref David Ebbo
          // As implemented, this identifier is merely the Type of the attribute. However, 
          // it is intended that the unique identifier be used to identify two 
          // attributes of the same type.
          public override object TypeId { get { return this; } }
          public TableView TableViews { get; set; }
          public RowView RowViews { get; set; }
          public RowAction Actions { get; set; }
          public String[] AllowedRoles { get; set; }
          public int Width { get; set; }
          public int Height { get; set; }
          public string DisplayName { get; set; }
//-------------------------------------------------------------------------------------------
          public DataAccess(TableView views, params String[] allowedRoles)
          {
               this.TableViews = views;
               this.AllowedRoles = allowedRoles;
          }
//-------------------------------------------------------------------------------------------
          public DataAccess(TableView view, int _width, int _height, string DisplayName = null, params String[] roles)
          {
               this.TableViews = view;
               this.AllowedRoles = roles;
               this.Width = _width;
               this.Height = _height;
          }
//-------------------------------------------------------------------------------------------
          public DataAccess(RowView view, params String[] roles)
          {
               this.RowViews = view;
               this.AllowedRoles = roles;
          }
//-------------------------------------------------------------------------------------------
          public DataAccess(RowAction actions, params String[] roles)
          {
               this.Actions = actions;
               this.AllowedRoles = roles;
          }
//-------------------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------
          public Boolean HasRole(string role)
          {
               String[] rolesLower = AllowedRoles.AllToLower();
               return rolesLower.Contains(role.ToLower());
          }
//-------------------------------------------------------------------------------------------
     }
}