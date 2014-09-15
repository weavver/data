using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Specialized;
using Weavver.Model;
using System.Reflection;
using System.IO;

namespace Weavver.Data
{
     [MetadataType(typeof(Sales_ShoppingCartItems.Metadata))]
     [DisplayName("Shopping Cart")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [Serializable()]
     partial class Sales_ShoppingCartItems : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               public object OrganizationId;
               public object SessionId;
               public object ProductId;

               public object Notes;
               public object Quantity;
               public object Deposit;
               public object Monthly;
               public object SetUp;
               public object Name;

               [Display(Name = "Back Link", Order = 1)]
               public object BackLink;

               //[ScaffoldColumn(false)]
               //public object RequiresOrganizationId;

               public object UnitCost;

               [ReadOnly(true)]
               public object CreatedAt;

               [ScaffoldColumn(false)]
               public object CreatedBy;

               [ScaffoldColumn(false)]
               [ReadOnly(true)]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object UpdatedBy;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Call Lead", "Administrators")]
          public DynamicDataWebMethodReturnType CallLead()
          {
               // initialize callback to lead's ph #
               // implement code
               return null;
          }
//-------------------------------------------------------------------------------------------
          public static Sales_ShoppingCartItems GetInstance(string searchPath, string pluggedInType)
          {
               //Sales_ShoppingCartItems.GetInstance(Server.MapPath("~/bin/"), "Weavver.Snap.SnapProduct");
               if (!String.IsNullOrEmpty(searchPath) && !String.IsNullOrEmpty(pluggedInType))
               {
                    string[] files = System.IO.Directory.GetFiles(searchPath, "*.dll");
                    for (int i = 0; i < files.Length; i++)
                    {
                         string filename = Path.GetFileNameWithoutExtension(files[i]);

                         Type ObjType = null;
                         try
                         {
                              // load it
                              Assembly ass = Assembly.Load(filename);
                              if (ass != null)
                              {
                                   ObjType = ass.GetType(pluggedInType);
                              }
                         }
                         catch (Exception ex)
                         {
                              Console.WriteLine(ex.Message);
                         }
                         try
                         {
                              if (ObjType != null)
                              {
                                   return (Sales_ShoppingCartItems) Activator.CreateInstance(ObjType);
                              }
                         }
                         catch (Exception ex)
                         {
                              Console.WriteLine(ex.Message);
                         }
                    }
               }
               return new Sales_ShoppingCartItems();
          }
//-------------------------------------------------------------------------------------------
     }
}