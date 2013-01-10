using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.DynamicData;

namespace Weavver.Data
{
     [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
     public class ColumnGroupAttribute : System.Attribute
     {
          public ColumnGroupAttribute(string groupName)
          {
               this._GroupName = groupName;
          }

          private string _GroupName;

          public string GroupName
          {
               get { return this._GroupName; }
               set { this._GroupName = value; }
          }
     }
}