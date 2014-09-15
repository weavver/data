using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Weavver.Data
{
     [MetadataType(typeof(HR_Applications.Metadata))]
     [DisplayName("Applications")]
     [DisplayColumn("Title")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators", "Guest")]
     partial class HR_Applications : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               //[ScaffoldColumn(false)]
               //public object Logistics_Organizations;

               [Display(Name = "Email Address")]
               public object EmailAddress;

               [Display(Name = "First Name")]
               public object NameFirst;

               [Display(Name = "Last Name")]
               public object NameLast;

               [Display(Name = "Cover Letter")]
               [UIHint("Code")]
               public object CoverLetter;

               [Display(Name = "Resume")]
               public object ResumePath;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
     }
}

     //     Currently, we are only accepting applications from potential contributors. If you would like to contribute
     //     to Weavver please submit your application below.<br />
     //     <br />
     //     We are open to growing contributors into full time positions as well as holding liabilities
     //     against your services.<br />
     //     <br />
     //     <hr />
     //     <br />
     //     Please include your resume along with a brief description about yourself, your passions, and interests in open source:<br />
     //<asp:Panel ID="Interview" runat="server">
     //     <h2>Interview</h2>
     //     Please answer the following questions to begin your interview.<br />
     //     <br />
     //     <table>
     //     <tr>
     //          <td>Q:</td><td>If you were a fruit, what kind of fruit would you be?</td>
     //     </tr>
     //     <tr>
     //          <td>A:</td>
     //          <td><asp:TextBox ID="WhatFruit" runat="server"></asp:TextBox></td>
     //     </tr>
     //     <tr>
     //          <td>Q:</td><td>Why are man hole covers round?</td>
     //     </tr>
     //     <tr>
     //          <td>A:</td>
     //          <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
     //     </tr>
     //     <tr>
     //          <td></td>
     //          <td><asp:Button ID="Button1" runat="server" Text="Submit" Enabled="false" /></asp:TextBox></td>
     //     </tr>
     //     </table>
     //     <br />
     //</asp:Panel>