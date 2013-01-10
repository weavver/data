using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.DynamicData;
using System.Web.UI;

namespace Weavver.Data
{
     public static class FileUploadHelper
     {
          // SAMPLE META DATA:
          //[UIHint("FileUpload")]
          //[FileUpload(
          //    FileUrl = "~/files/{0}",
          //    FileTypes = new String[] { "pdf", "xls", "doc", "xps" },
          //    DisplayImageType = "png",
          //    DisableHyperlink = false,
          //    HyperlinkRoles = new String[] { "Admin", "Accounts" },
          //    DisplayImageUrl = "~/images/{0}")]
          //[ImageFormat(22, 0)]
          /// <summary>
          /// If the given table contains a column that has a UI Hint with the value "DbImage", finds the ScriptManager
          /// for the current page and disables partial rendering
          /// </summary>
          /// <param name="page"></param>
          /// <param name="table"></param>
          public static void DisablePartialRenderingForUpload(Page page, MetaTable table)
          {
               foreach (var column in table.Columns)
               {
                    // TODO this depends on the name of the field template, need to fix
                    if (String.Equals(column.UIHint, "DBImage", StringComparison.OrdinalIgnoreCase) &&
                        String.Equals(column.UIHint, "FileImage", StringComparison.OrdinalIgnoreCase) &&
                        String.Equals(column.UIHint, "FileUpload", StringComparison.OrdinalIgnoreCase))
                    {
                         var sm = ScriptManager.GetCurrent(page);
                         if (sm != null)
                         {
                              sm.EnablePartialRendering = false;
                         }
                         break;
                    }
               }
          }
     }
}
