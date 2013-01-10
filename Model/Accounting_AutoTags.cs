using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Model
{
     class Accounting_AutoTags
     {
          //<div id="tags">
          //     Tags allow you to categorize your transactions and break them down into automatic reports.<br />
          //     <br />
          //     <table>
          //     <tr>
          //          <td>Name</td>
          //          <td><asp:TextBox ID="TagName" runat="server"></asp:TextBox></td>
          //     </tr>
          //     <tr>
          //          <td>Starts with</td>
          //          <td><asp:TextBox ID="TagStartsWith" runat="server"></asp:TextBox></td>
          //     </tr>
          //     <tr>
          //          <td></td>
          //          <td><asp:Button ID="TagAdd" runat="server" Text="Add Tag" Height="30px" OnClick="TagAdd_Click" /><br /></td>
          //     </tr>
          //     </table>
          //     <br />
          //     <asp:DataGrid ID="TagList" runat="server" HeaderStyle-BackColor="BurlyWood" Width="100%" AutoGenerateColumns="false">
          //     <Columns>
          //          <asp:BoundColumn HeaderText="Name" ItemStyle-Width="300px" DataField="Name" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
          //          <asp:BoundColumn ItemStyle-Width="" HeaderText="StartsWith" DataField="StartsWith" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
          //          <asp:ButtonColumn ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" Text="Delete"></asp:ButtonColumn>
          //     </Columns>
          //     </asp:DataGrid> 
          //</div>
     }
}

//command.CommandText = "select * from Accounting_LedgerItemTags where OrganizationId=@OrganizationId order by [Name]";
//SqlDataReader reader = command.ExecuteReader();
//TagList.DataSource = reader;
//TagList.DataBind();
//reader.Close();

//GenTagMonthReport();

               //<asp:DataGrid ID="TagsByMonth" runat="server" HeaderStyle-BackColor="BurlyWood" Width="100%" AlternatingItemStyle-BackColor="#edf3fe" AutoGenerateColumns="false">
               //     <Columns>
               //          <asp:BoundColumn HeaderText="Tag" ItemStyle-Width="100px" DataField="Tag" ItemStyle-HorizontalAlign="Left"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="January" ItemStyle-Width="100px" DataField="January" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="February" ItemStyle-Width="100px" DataField="February" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="March" ItemStyle-Width="100px" DataField="March" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="April" ItemStyle-Width="100px" DataField="April" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="May" ItemStyle-Width="100px" DataField="May" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="June" ItemStyle-Width="100px" DataField="June" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="July" ItemStyle-Width="100px" DataField="July" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="August" ItemStyle-Width="100px" DataField="August" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="September" ItemStyle-Width="100px" DataField="September" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="October" ItemStyle-Width="100px" DataField="October" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="November" ItemStyle-Width="100px" DataField="November" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="December" ItemStyle-Width="100px" DataField="December" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //          <asp:BoundColumn HeaderText="Total" ItemStyle-Width="100px" DataField="Total" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"></asp:BoundColumn>
               //     </Columns>
               //</asp:DataGrid>


////-------------------------------------------------------------------------------------------
//     protected void TagAdd_Click(object sender, EventArgs e)
//     {
//          TagRuleAdd(TagName.Text, TagStartsWith.Text);
//     }
////-------------------------------------------------------------------------------------------
//     public void TagRuleAdd(string name, string rule)
//     {
//          SqlCommand command = new SqlCommand("Insert into Accounting_LedgerItemTags (Id, OrganizationId, [Name], StartsWith) Values(@Id, @OrganizationId, @Name, @StartsWith)", wvvrdb.MSSQLDB);
//          command.Parameters.Add("Id", Guid.NewGuid());
//          command.Parameters.Add("OrganizationId", SelectedOrganization.Id);
//          command.Parameters.Add("Name", name);
//          command.Parameters.Add("StartsWith", rule);

//          command.ExecuteNonQuery();
//     }
////-------------------------------------------------------------------------------------------
//     public void GenTagMonthReport()
//     {
//          string query = @"select 
//	                    'OrganizationId' = matches.OrganizationId,
//	                    'Tag' = matches.tagname,
//	                    'January' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 1
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'February' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 2
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'March' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 3
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'April' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 4
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'May' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 5
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'June' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 6
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'July' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 7
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'August' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 8
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.Account = @Account),
//	                    'September' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 9
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.OrganizationId = @Account),
//	                    'October' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 10
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.OrganizationId = @Account),
//	                    'November' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 11
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = matches.OrganizationId
//		                    and li.OrganizationId = @Account),
//	                    'December' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where li.Name Like t1.StartsWith + '%'
//		                    and MONTH(postat) = 12
//		                    and YEAR(postat) = @Year
//		                    and t1.Name = matches.tagname
//		                    and t1.OrganizationId = @OrganizationId
//		                    and li.OrganizationId = @Account),
//	                    'Total' = (select sum(amount) from Accounting_LedgerItems li, Accounting_LedgerItemTags t1
//		                    where
//                                   li.OrganizationId = @OrganizationId and
//                                   li.Account = @Account and
//                                   li.Name Like t1.StartsWith + '%' and
//                                   YEAR(postat) = @Year and
//                                   t1.OrganizationId = matches.OrganizationId and
//                                   t1.Name = matches.tagname
//	                    from
//	                    (select 'OrganizationId' = tags.OrganizationId, 'TagName' = tags.Name
//                         from Accounting_LedgerItems items, Accounting_LedgerItemTags tags
//	                     where items.Name Like tags.StartsWith + '%' and
//	                     items.OrganizationId = @OrganizationId and
//                          items.Account = @Account
//                         group by tags.Name, tags.OrganizationId
//	                    ) as matches";

//          SqlCommand command = new SqlCommand(query, wvvrdb.MSSQLDB);
//          command.Parameters.Add("OrganizationId", SelectedOrganization.Id);
//          command.Parameters.Add("Account", accountId);
//          command.Parameters.Add("Year", 2010);

//          //SqlDataReader reader = command.ExecuteReader();
//          //TagsByMonth.DataSource = reader;
//          //TagsByMonth.DataBind();
//          //reader.Close();
//     }