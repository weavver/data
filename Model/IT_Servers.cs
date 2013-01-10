using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Data.Objects.DataClasses;

namespace Weavver.Data
{
     [MetadataType(typeof(IT_Servers.Metadata))]
     [DisplayName("Servers")]
     [SecureTable(TableActions.List, "Administrators")]
     [SecureTable(TableActions.Edit, "Administrators")]
     [SecureTable(TableActions.Details, "Administrators")]
     [SecureTable(TableActions.Delete, "Administrators")]
     [SecureTable(TableActions.Insert, "Administrators")]
     partial class IT_Servers : IAuditable
     {
//-------------------------------------------------------------------------------------------
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(Name="Name", Order=5)]
               [FilterUIHint("String")]
               public object ServerName;

               [Display(Name = "MAC Address", Order = 10)]
               public object MAC;

               [Display(Name = "IP Address", Order = 15)]
               public object IPAddress;

               [ScaffoldColumn(true)]
               public object IsPoweredOn;

               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object CreatedAt;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
//-------------------------------------------------------------------------------------------
          //[EdmScalarPropertyAttribute(EntityKeyProperty = false, IsNullable = false)]
          [DataMemberAttribute()]
          public bool IsPoweredOn
          {
               get
               {
                    return false;
               }
               set
               {
               }
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Send WOL Packet", "IT Staff")]
          public DynamicDataWebMethodReturnType WakeOnLan()
          {
               // implement code
               return null;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Turn On Power", "IT Staff")]
          public DynamicDataWebMethodReturnType TurnOnPower()
          {
               // do the power up

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "The server is turning on..";
               ret.Message = "Please wait while your server spins up.";
               ret.Exception = false;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Reboot", "IT Staff")]
          public DynamicDataWebMethodReturnType Reboot()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "The server is restarting..";
               ret.Message = "Please wait while your server restarts.";
               ret.Exception = false;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Turn Off Power", "IT Staff")]
          public DynamicDataWebMethodReturnType TurnOffPower()
          {
               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "The server is turning off..";
               ret.Message = "Please wait your server is turning off!";
               ret.Exception = false;
               return ret;
          }
//-------------------------------------------------------------------------------------------
     }
}