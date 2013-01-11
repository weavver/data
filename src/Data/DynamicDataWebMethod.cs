using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     public enum DynamicMethodScope
     {
          Table,
          Row
     }

     [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
     public class DynamicDataWebMethod : System.Attribute
     {
          public DynamicMethodScope Scope;
          public string MethodName { get; set; }
          public String[] Roles { get; set; }

          public DynamicDataWebMethod(string methodname, params String[] roles)
          {
               this.MethodName = methodname;
               this.Roles = roles;
          }

          public DynamicDataWebMethod(DynamicMethodScope _scope, string methodname, params String[] roles)
          {
               this.Scope = _scope;
               this.MethodName = methodname;
               this.Roles = roles;
          }
     }

     public class DynamicDataWebMethodReturnType
     {
          public bool Exception;
          public Exception Ex;
          public string Message { get; set; }
          public string Status { get; set; }
          public bool RedirectRequest { get; set; }
          public string RedirectURL { get; set; }

          public string FileName { get; set; }
          public string FileMimeType { get; set; }
          public string FilePath { get; set; }
     }
}