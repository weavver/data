using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Weavver.Security
{
     public class WeavverMembershipUser : System.Web.Security.MembershipUser
     {
          public WeavverMembershipUser(string providername,
                         string username,
                         object providerUserKey,
                         string email,
                         string passwordQuestion,
                         string comment,
                         bool isApproved,
                         bool isLockedOut,
                         DateTime creationDate,
                         DateTime lastLoginDate,
                         DateTime lastActivityDate,
                         DateTime lastPasswordChangedDate,
                         DateTime lastLockedOutDate)
                              : base(providername,
                                   username,
                                   providerUserKey,
                                   email,
                                   passwordQuestion,
                                   comment,
                                   isApproved,
                                   isLockedOut,
                                   creationDate,
                                   lastLoginDate,
                                   lastActivityDate,
                                   lastPasswordChangedDate,
                                   lastLockedOutDate)
          {
               
          }

          public Weavver.Data.System_Users WeavverSysUser;
     }
}