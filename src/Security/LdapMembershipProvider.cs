using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using Weavver.Data;

namespace Weavver.Security
{
     public class LdapMembershipProvider : System.Web.Security.MembershipProvider
     {
//-------------------------------------------------------------------------------------------
          public override string ApplicationName
          {
               get
               {
                    throw new NotImplementedException();
               }
               set
               {
                    throw new NotImplementedException();
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool ChangePassword(string username, string oldPassword, string newPassword)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out System.Web.Security.MembershipCreateStatus status)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override bool DeleteUser(string username, bool deleteAllRelatedData)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override bool EnablePasswordReset
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override bool EnablePasswordRetrieval
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override int GetNumberOfUsersOnline()
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override string GetPassword(string username, string answer)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUser GetUser(string username, bool userIsOnline)
          {
               System_Users u = new System_Users();
               u.Id = Guid.NewGuid();
               u.Username = username;
               u.Activated = true;
               u.OrganizationId = new Guid("0baae579-dbd8-488d-9e51-dd4dd6079e95");
               return new WeavverMembershipUser("LdapMembershipProvider", username, u.Id, u.EmailAddress, u.PasswordQuestion, null, u.Activated,
                    u.Locked, u.CreatedAt, u.LastLoggedIn.Value, u.LastLoggedIn.Value, DateTime.UtcNow, DateTime.UtcNow);


               //var user = GetUser(username);
               //if (user != null)
               //{
               //     WeavverMembershipUser wvvrMembershipUser = new WeavverMembershipUser("WeavverMembershipProvider", user.Username, user.Id, user.EmailAddress, "none", "", user.Activated, false, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, DateTime.UtcNow, user.CreatedAt.Value);
               //     wvvrMembershipUser.WeavverSysUser = user;
               //     return wvvrMembershipUser;
               //}
               //else
               //{
               //     return null;
               //}
          }
//-------------------------------------------------------------------------------------------
          public Weavver.Data.System_Users GetUser(string username)
          {
               //Weavver.Sys.User item = new Sys.User();
               //return item;

               return null;
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipUser GetUser(object providerUserKey, bool userIsOnline)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override string GetUserNameByEmail(string email)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override int MaxInvalidPasswordAttempts
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override int MinRequiredNonAlphanumericCharacters
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override int MinRequiredPasswordLength
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override int PasswordAttemptWindow
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override System.Web.Security.MembershipPasswordFormat PasswordFormat
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override string PasswordStrengthRegularExpression
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override bool RequiresQuestionAndAnswer
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override bool RequiresUniqueEmail
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override string ResetPassword(string username, string answer)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override bool UnlockUser(string userName)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override void UpdateUser(System.Web.Security.MembershipUser user)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override bool ValidateUser(string username, string password)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
     }
}
