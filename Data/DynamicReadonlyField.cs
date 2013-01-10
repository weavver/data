using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Web.DynamicData;

namespace Weavver.Data
{
     public class DynamicReadonlyField : DynamicField
     {
          public override void InitializeCell(
               DataControlFieldCell cell,
               DataControlCellType cellType,
               DataControlRowState rowState,
               int rowIndex)
          {
               if (cellType == DataControlCellType.DataCell)
               {
                    var control = new DynamicControl() { DataField = DataField };

                    // Copy various properties into the control
                    control.UIHint = UIHint;
                    control.HtmlEncode = HtmlEncode;
                    control.NullDisplayText = NullDisplayText;

                    // this the default for DynamicControl and has to be 
                    // manually changed you do not need this line of code
                    // its there just to remind us what we are doing.
                    control.Mode = DataBoundControlMode.ReadOnly;

                    cell.Controls.Add(control);
               }
               else
               {
                    base.InitializeCell(cell, cellType, rowState, rowIndex);
               }
          }
     }
}
