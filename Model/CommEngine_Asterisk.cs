using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Weavver.Data
{
     class CommEngine_Asterisk
     {
          
     
               //Weavver.Connect.BridgedCall bc = (Weavver.Connect.BridgedCall) deserializer.Deserialize(textReader);
               //bc.Connect();
//     <table>
//     <tr>
//          <td>Phone Number 1:</td>
//          <td><asp:TextBox ID="PhoneNumber1" runat="server"></asp:TextBox></td>
//     </tr>
//     <tr>
//          <td>Phone Number 2:</td>
//          <td><asp:TextBox ID="PhoneNumber2" runat="server"></asp:TextBox></td>
//     </tr>
//     <tr>
//          <td></td>
//          <td><asp:Button ID="Dial" runat="server" Text="Dial" Width="150" Height="25" OnClick="Dial_Click"></asp:Button></td>
//     </tr>
//     </table>

//          * Please make sure that port 5038 is accessible for our IP address 205.134.225.18.
//     <br />
//     You can use our calling widget to connect your website with your Asterisk phone system:<br />
//     <br />
//     <a href="DialerDemo.html" target="_blank">Click here for a Demo</a><br />
//     <br />
//     <table>
//     <tr>
//          <td valign="top">Code:</td>
//          <td><asp:TextBox ID="WidgetCode" runat="server" TextMode="MultiLine" Width="600px" Height="230"></asp:TextBox></td>
//     </tr>
//     </table>
//     <br />
//     Please be careful to maintain your inbound and outbound routes on your phone system carefully to avoid fraud.
////-------------------------------------------------------------------------------------------
//     protected void GenerateCode()
//     {
//          string jsCode = "<script type=\"text/javascript\">\r\n" +
//               "     var wvvrSnapJsHost = ((\"https:\" == document.location.protocol) ? \"https://www.\" : \"http://www.\");\r\n" +
//               "     document.write(unescape(\"%3Cscript src='\" + wvvrSnapJsHost + \"weavver.com/company/information_technology/dialer.js' type='text/javascript'%3E%3C/script%3E\"));\r\n" +
//          "</script>\r\n" +
//          "<script type=\"text/javascript\">\r\n" +
//          "     try {\r\n" +
//          "          var wvvrDialer = _gat._getTracker(\"{0}\");\r\n" +
//          "          wvvrDialer._activate();\r\n" +
//          "     } catch (err) { }\r\n" +
//          "</script>";
//          jsCode = jsCode.Replace("{0}", Request["id"].ToString());

//          WidgetCode.Text = jsCode;
//     }
////-------------------------------------------------------------------------------------------
//     public void Dial_Click(object sender, EventArgs e)
//     {
//          AsteriskPhoneSystem callserver = DatabaseHelper.Session.Get<AsteriskPhoneSystem>(new Guid(Request["id"]));
//          AsteriskConnection phonesystem = new AsteriskConnection();
//          phonesystem.Connect(callserver.ManagerUsername, callserver.ManagerPassword, callserver.Host);
//          AsteriskPackets asteriskPacket = new AsteriskPackets();
//          string packet = AsteriskPackets.OriginatePacket("SIP/1420", "5920", "weavver", "17148725920");
//          phonesystem.SendPacket(packet);
//          phonesystem.Disconnect();
//          Response.Write("Dialing using " + callserver.Host + ":" + callserver.ManagerUsername + ":" + callserver.ManagerPassword + "!");
//     }
////-------------------------------------------------------------------------------------------
//     public void ImportCSV_Click(object sender, EventArgs e)
//     {
//          //CDRManager cdrMan = new Weavver.Voice.CDRManager();
//          //cdrMan.ProcessCSV(@"W:\Desktop\Catapult.csv", SelectedOrganization.Id);
//     }
     }
}
