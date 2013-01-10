using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weavver.Data
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field , AllowMultiple = false)]
    public class InsertTitleAttribute : System.Attribute
    {
         public InsertTitleAttribute(string title)
          {
               this._title = title;
          }

        private string _title;
        public string Title
        {
             get { return this._title; }
             set { this._title = value; }
        }
    }
}
