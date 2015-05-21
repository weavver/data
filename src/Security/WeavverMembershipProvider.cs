using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Configuration;
using Weavver.Data;

namespace Weavver.Security
{
     /// <summary>
     /// Summary description for WeavverMembershipProvider
     /// </summary>
     public class WeavverMembershipProvider : System.Web.Security.MembershipProvider
     {
//-------------------------------------------------------------------------------------------
          private string applicationname;
//-------------------------------------------------------------------------------------------
          public WeavverMembershipProvider()
          {
          }
//-------------------------------------------------------------------------------------------
          public override string ApplicationName
          {
               get
               {
                    if (HttpContext.Current.Items.Contains("ApplicationName"))
                         return (string) HttpContext.Current.Items["ApplicationName"];
                    else
                         return "Weavver";
               }
               set
               {
                    applicationname = value;
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool ValidateUser(string username, string password)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var item = (from x in data.System_Users
                                where x.Username == username &&
                                      x.Password == password
                                select x).FirstOrDefault();

                    if (item != null)
                    {
                         item.LastLoggedIn = DateTime.UtcNow;
                         //data.SaveChanges();
                    }
                    return (item != null);
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool ChangePassword(string username, string oldPassword, string newPassword)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var user = (from x in data.System_Users
                               where x.Username == username &&
                                     x.Password == oldPassword
                               select x).FirstOrDefault();

                    if (user != null)
                    {
                         user.Password = newPassword;
                         data.SaveChanges();
                         return true;
                    }
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var user = (from x in data.System_Users
                                where x.Username == username &&
                                      x.Password == password
                                select x).First();
                    if (user != null)
                    {
                         user.PasswordQuestion = newPasswordQuestion;
                         user.PasswordAnswer = newPasswordAnswer;
                         data.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
          {
               return CreateUser(username, password, email, passwordQuestion, passwordAnswer, isApproved, providerUserKey, null, null, out status);
          }
//-------------------------------------------------------------------------------------------
          public MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, string userhostaddress, string referredby, out MembershipCreateStatus status)
          {
               username = username.ToLower();
               email = email.ToLower();
               
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    System_Users user = new System_Users();
                    user.EmailAddress = email;
                    user.Username = username;
                    user.Password = password;
                    user.ReferredBy = referredby;
                    Random rHash = new Random();
                    string seed = rHash.Next().ToString() + rHash.Next().ToString() + rHash.Next().ToString() + rHash.Next().ToString();
                    user.ActivationKey = MD5Hash(seed);
                    user.LastLoggedIn = DateTime.UtcNow;
                    user.UpdatedAt = DateTime.UtcNow;
                    user.UpdatedBy = Guid.Empty;
                    user.CreatedAt = DateTime.UtcNow;
                    user.CreatedBy = Guid.Empty;

                    // todo: add account note, signed up from "ip address" - user.CreatedBy = userhostaddress;
                    data.System_Users.Add(user);
                    if (data.SaveChanges() > 0)
                    {
                         status = MembershipCreateStatus.Success;
                         return GetUser(username, false);
                    }
                    else
                    {
                         status = MembershipCreateStatus.ProviderError;
                         return null;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool DeleteUser(string username, bool deleteAllRelatedData)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var user = (from x in data.System_Users
                                where x.Username == username
                                select x).First();

                    if (user != null)
                    {
                         user.Locked = true;
                         data.SaveChanges();
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool EnablePasswordReset
          {
               get
               {
                    return true;
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool EnablePasswordRetrieval
          {
               get
               {
                    return true;
               }
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
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
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var user = (from x in data.System_Users
                                where x.Username == username &&
                                x.PasswordAnswer == answer
                                select x).First();
                    return (user == null) ? null : user.Password;
               }
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUser GetUser(string username, bool userIsOnline)
          {
               var user = GetUser(username);
               if (user != null)
               {
                    WeavverMembershipUser wvvrMembershipUser = new WeavverMembershipUser("WeavverMembershipProvider",
                         user.Username,     //username
                         user.Id,           //provideruserkey
                         user.EmailAddress, //email address
                         "none",            //password question
                         "",                //content
                         user.Activated,    //isapproved/activated
                         false,             //islockedout
                         DateTime.UtcNow,   //creation date
                         DateTime.UtcNow,   //last login
                         DateTime.UtcNow,   //last active
                         DateTime.UtcNow,   //last passwordchange
                         user.CreatedAt);   //last locked out
                    wvvrMembershipUser.WeavverSysUser = user;
                    return wvvrMembershipUser;
               }
               else
               {
                    return null;
               }
          }
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// Grabs the user from the database and loads it into Weavver.Sys.User;
          /// </summary>
          /// <param name="username"></param>
          /// <returns></returns>
          public System_Users GetUser(string username)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var user = (from x in data.System_Users
                                where x.Username == username
                                select x).FirstOrDefault();

                    if (user != null)
                    {
                         data.Entry(user).State = System.Data.Entity.EntityState.Detached;
                    }
                    return user;
               }
          }
//-------------------------------------------------------------------------------------------
          public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public override string GetUserNameByEmail(string email)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Guid orgId = new Guid(HttpContext.Current.Session["SelectedOrganizationId"].ToString());
                    var user = (from x in data.System_Users
                               where (x.EmailAddress == email && x.OrganizationId == orgId)
                               select x).Take(1);

                    return (user.Count() > 0) ? null : user.First().Username;
               }
          }
//-------------------------------------------------------------------------------------------
          public override int MaxInvalidPasswordAttempts
          {
               get
               {
                    return 4;
               }
          }
//-------------------------------------------------------------------------------------------
          public override int MinRequiredNonAlphanumericCharacters
          {
               get
               {
                    return 1;
               }
          }
//-------------------------------------------------------------------------------------------
          public override int MinRequiredPasswordLength
          {
               get
               {
                    return 6;
               }
          }
//-------------------------------------------------------------------------------------------
          public override int PasswordAttemptWindow
          {
               get { throw new NotImplementedException(); }
          }
//-------------------------------------------------------------------------------------------
          public override MembershipPasswordFormat PasswordFormat
          {
               get
               {
                    return MembershipPasswordFormat.Clear;
               }
          }
//-------------------------------------------------------------------------------------------
          public override string PasswordStrengthRegularExpression
          {
               get
               {
                    return "^.*(?=.{6,})(?=.*\\d).*$";
               }
          }
//-------------------------------------------------------------------------------------------
          // should add this later
          public override bool RequiresQuestionAndAnswer
          {
               get
               {
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool RequiresUniqueEmail
          {
               get
               {
                    return true;
               }
          }
//-------------------------------------------------------------------------------------------
          public override string ResetPassword(string username, string answer)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    System_Users item = (from x in data.System_Users
                                        where x.Username == username
                                        select x).First();

                    Random r = new Random();
                    string newPass = "";
                    for (int i = 0; i < 8; i++)
                    {
                         newPass += (char)r.Next(57) + 65;
                    }
                    item.Password = newPass;
                    data.SaveChanges();

                    return item.Password;
               }
          }
//-------------------------------------------------------------------------------------------
          public override bool UnlockUser(string userName)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var employee = GetUser(userName);
                    if (employee != null)
                    {
                         employee.Activated = true;
                         
                         return true;
                    }
                    else
                    {
                         return false;
                    }
               }
          }
//-------------------------------------------------------------------------------------------
          public override void UpdateUser(MembershipUser user)
          {
               throw new NotImplementedException();
          }
//-------------------------------------------------------------------------------------------
          public void SendUserActivationInstructions(string username, string baseURL)
          {
               var employee = GetUser(username);
               string activateURL = baseURL + "/account/activate?activationKey=" + employee.ActivationKey;

               MailMessage mWelcome = new MailMessage("Weavver <system@weavver.com>", employee.EmailAddress);
               mWelcome.Subject = "Please activate your Weavver ID";
               //mm.Body = CreateUserWizard1.Email;
               mWelcome.Body = "Thank you for registering your Weavver ID.<br />\r\n<br />\r\n";
               mWelcome.Body += "Please activate your account using the following link:<br />\r\n";
               mWelcome.Body += "<a href=\"" + activateURL + "\">" + activateURL + "</a><br /><br />";
               mWelcome.Body += "Or use the following code:<br />" + employee.ActivationKey + "<br /><br />";
               mWelcome.IsBodyHtml = true;
               mWelcome.Body += "define: organization<br />";
               mWelcome.Body += "1. a group of people who work together<br />";
               mWelcome.Body += "2. cause to be structured or ordered or operating according to some principle or idea<br />";

               System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp_server"]);
               client.Send(mWelcome);
          }
//-------------------------------------------------------------------------------------------
          private string MD5Hash(string input)
          {
               MD5 md5Hasher = MD5.Create();
               byte[] data = md5Hasher.ComputeHash(System.Text.Encoding.Default.GetBytes(input));
               System.Text.StringBuilder sBuilder = new System.Text.StringBuilder();
               for (int i = 0; i < data.Length; i++)
               {
                    sBuilder.Append(data[i].ToString("x2"));
               }
               return sBuilder.ToString();
          }
//-------------------------------------------------------------------------------------------
          public bool ActivateUser(string username, string keyToTest)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                   var user = (from x in data.System_Users
                              where x.Username == username
                              select x).First();

                    if (user != null &&
                         (user.ActivationKey == keyToTest ||
                          keyToTest == ConfigurationManager.AppSettings["activation_bypasskey"]))
                    {
                         user.Activated = true;
                         data.SaveChanges();
                         return true;
                    }
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
     }
}