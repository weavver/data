using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Weavver.Vendors.APC;

namespace Weavver.Data
{
     partial class IT_RemotePowerUnits
     {
          public MasterSwitch ms = new MasterSwitch();
//-------------------------------------------------------------------------------------------
          protected void Port1_Click(object sender, EventArgs e)
          {
               //add a confirm before rebooting the port
               ms.RestartPort(1, PowerAction.ImmediateReboot);
               //if (ms.RestartAllPorts(WeavverLib.APC.PowerAction.ImmediateReboot))
               //{
               //     Response.Write("Rebooted");
               //}
               //else
               //{
               //     Response.Write("Fail");
               //}
          }
//-------------------------------------------------------------------------------------------
          protected void Port2_Click(object sender, EventArgs e)
          {
               ms.RestartPort(2, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port3_Click(object sender, EventArgs e)
          {
               ms.RestartPort(3, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port4_Click(object sender, EventArgs e)
          {
               ms.RestartPort(4, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port5_Click(object sender, EventArgs e)
          {
               ms.RestartPort(5, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port6_Click(object sender, EventArgs e)
          {
               ms.RestartPort(6, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port7_Click(object sender, EventArgs e)
          {
               ms.RestartPort(7, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
          protected void Port8_Click(object sender, EventArgs e)
          {
               ms.RestartPort(8, PowerAction.ImmediateReboot);
          }
//-------------------------------------------------------------------------------------------
     }
}
