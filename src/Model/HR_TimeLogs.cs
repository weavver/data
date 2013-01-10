using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(HR_TimeLogs.Metadata))]
     [DisplayName("Time Logs")]
     [SecureTable(TableActions.List, "Administrators", "Employee")]
     [SecureTable(TableActions.Edit, "Administrators", "Employee")]
     [SecureTable(TableActions.Details, "Administrators", "Employee")]
     [SecureTable(TableActions.Delete, "Administrators", "Employee")]
     [SecureTable(TableActions.Insert, "Administrators", "Employee")]
     partial class HR_TimeLogs : IAuditable, IValidator
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [Display(Name = "Start", Order=1)]
               public object Start;

               [Display(Name = "End", Order=5)]
               public object End;

               //[HideColumnIn(PageTemplate.List)]
               [Display(Order = 6)]
               [FilterUIHint("String")]
               public object Memo;

               [Display(Name = "Duration", Order = 7)]
               [ScaffoldColumn(true)]
               [UIHint("TimeSpan")]
               public object Duration;

               [ReadOnly(true)]
               [Display(Name = "Earned", Order = 8)]
               public object Earned;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [Display(Name="Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               //TODO TIME LIMIT FEATURE: When you punch in time will not start being logged until 9:00AM PST and you will be automatically logged out at 12PM.

               Valid = true;
               ErrorMessage = null;
          }
//-------------------------------------------------------------------------------------------
//          public string TotalTime_ForPerson(Guid organizationId, Guid PersonId)
//          {
//               string sql = "select isnull(sum(DATEDIFF(Second, [In], [Out])), 0) from hr_timelogs where personid=@PersonId and OrganizationId=@OrganizationId";

//               SqlConnection dbconnection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["weavver"].ConnectionString);
//               dbconnection.Open();
//               SqlCommand dbcommand = new SqlCommand(sql, dbconnection);
//               dbcommand.Parameters.AddWithValue("@OrganizationId", organizationId);
//               dbcommand.Parameters.AddWithValue("@Personid", PersonId);
//               object totalTime = (int) dbcommand.ExecuteScalar();
//               return Weavver.Common.Common.GetHumanFriendlyTimeString(Convert.ToDouble(totalTime));
//          }
////-------------------------------------------------------------------------------------------
//          public void PunchIn(Guid OrganizationId, Guid employeeId)
//          {
//               TimeLog item = new TimeLog();
//               item.DatabaseHelper = DatabaseHelper;
//               item.OrganizationId = OrganizationId;
//               item.PersonId = employeeId;
//               item.DateTimeIn = DateTime.UtcNow;
//               item.CreatedAt = DateTime.UtcNow;
//               item.CreatedBy = employeeId;
//               item.UpdatedAt = DateTime.UtcNow;
//               item.UpdatedBy = employeeId;
//               item.Commit();
//          }
////-------------------------------------------------------------------------------------------
//          public void PunchOut(Guid TimeLogId)
//          {
//               TimeLog log = DatabaseHelper.Session.Get<TimeLog>(TimeLogId);
//               log.DatabaseHelper = DatabaseHelper;
//               log.DateTimeOut = DateTime.UtcNow;
//               TimeSpan duration = log.DateTimeOut.Value - log.DateTimeIn;
//               Employee emp = DatabaseHelper.Session.Get<Employee>(log.PersonId);
//               emp.DatabaseHelper = DatabaseHelper;
//               log.Earned = emp.CalculateWage(duration);
//               log.Commit();
//          }
//-------------------------------------------------------------------------------------------
     }
}