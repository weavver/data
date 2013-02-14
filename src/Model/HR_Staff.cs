using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(HR_Staff.Metadata))]
     //[DisplayColumn("DisplayName", "username", false)]
     [DisplayName("Staff")]
     [SecureTable(TableActions.List, "Administrators", "Human Resources")]
     [SecureTable(TableActions.Edit, "Administrators", "Human Resources")]
     [SecureTable(TableActions.Details, "Administrators", "Human Resources")]
     [SecureTable(TableActions.Delete, "Administrators", "Human Resources")]
     [SecureTable(TableActions.Insert, "Administrators", "Human Resources")]
     partial class HR_Staff : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [FilterUIHint("String")]
               [Display(Order = 1)]
               public object Status;

               [Display(Name = "First Name", Order = 10)]
               //[FilterUIHint("String")]
               public object FirstName;

               [Display(Name = "Middle Name", Order = 15)]
               //[FilterUIHint("String")]
               public object MiddleName;

               [Display(Name = "Last Name", Order = 20)]
               [FilterUIHint("String")]
               public object LastName;

               [UIHint("EmailAddress")]
               [Display(Name = "Email Address", Order = 25)]
               public object EmailAddress;

               [HideColumnIn(PageTemplate.List)]
               [PasswordPropertyTextAttribute(true)]
               [Display(Name = "Username", Order = 26)]
               public object Username;

               [HideColumnIn(PageTemplate.List)]
               [UIHint("Password")]
               [PasswordPropertyTextAttribute(true)]
               [Display(Name = "Password", Order = 30)]
               public object Password;

               [HideColumnIn(PageTemplate.List)]
               //[UIHint("Text")]
               [PasswordPropertyTextAttribute(true)]
               [Display(Name = "Pass Code", Order = 35)]
               [UIHint("Password")]
               public object PassCode;

               [Display(Name = "Extension", Order = 80)]
               public object Extension;

               [ColumnGroup("Logistics")]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("Text")]
               [Display(Name = "Personal Days", Order = 40)]
               public object PersonalDays;

               [ColumnGroup("Logistics")]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("Text")]
               [Display(Name = "Sick Days", Order = 45)]
               public object SickDays;

               [ColumnGroup("Logistics")]
               [Display(Name = "Position", Order = 50)]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("Position")]
               public object Position;

               [ColumnGroup("Logistics")]
               [Display(Name = "Is Salaried", Order = 60)]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("IsSalaried")]
               public object IsSalaried;

               [ColumnGroup("Logistics")]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("HourlyWage")]
               [Display(Name = "Hourly Wage", Order = 65)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object HourlyWage;

               [ColumnGroup("Logistics")]
               [Display(Name = "Monthly Budget", Order = 70)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object MonthlyBudget;

               [ColumnGroup("Bio")]
               [Display(Name = "Location", Order = 55)]
               [HideColumnIn(PageTemplate.List)]
               //[UIHint("Location")]
               public object Location;

               [ColumnGroup("Bio")]
               [Display(Name = "Bio", Order = 75)]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object Bio;

               [FilterUIHint("DateTime")]
               [Display(Name = "Created At")]
               [ReadOnly(true)]
               public object CreatedAt;

               [FilterUIHint("DateTime")]
               [Display(Name="Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;

               [ScaffoldColumn(false)]
               public object Logistics_Organizations;

               [ScaffoldColumn(false)]
               public object Sales_Resellers;

               [HideColumnIn(PageTemplate.List)]
               public object HR_Tasks;
          }

          public override string ToString()
          {
               return LastName + ", " + FirstName;
          }

          //
          //if (System.IO.File.Exists(filePath))
          //{
          //     html = String.Format("<a href=\"/images/about/{0}.jpg\"><img alt=\"Picture of {1} {2}\" border=\"0\" src=\"/images/about/{0}.jpg\" style=\"float: right; width: 120px; margin-right: 0px; padding: 10px;\" /></a>", emp.Username, emp.FirstName, emp.LastName);
          //}
          //return html;
          
//-------------------------------------------------------------------------------------------
          /// <summary>
          /// 
          /// </summary>
          /// <param name="personId"></param>
          /// <returns>An empty Guid of if the person is not punched in. Or the Guid of the TimeLog.</returns>
          public bool IsPunchedIn()
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    var timeLog = (from x in data.HR_TimeLogs
                                  where (x.OrganizationId == OrganizationId &&
                                  x.PersonId == Id &&
                                  x.End != null)
                                  select x).First();

                    if (timeLog != null)
                    {
                         return true;
                    }
                    return false;
               }
          }
//-------------------------------------------------------------------------------------------
          public void ReceivableBalance()
          {
               //string arbalance = Accounting.Balance_ForLedger(LedgerType.Receivable, SelectedOrganization.Id, item.Id, null, null).ToString("C");
               //Master.AddAttachmentLink("Receivable Ledger " + arbalance, "~/company/accounting/ledger?ledgertype=Receivable&id=" + item.Id.ToString(), "");
          }
//-------------------------------------------------------------------------------------------
          public void PayableBalance()
          {
                //string apbalance = Accounting.Balance_ForLedger(LedgerType.Payable, SelectedOrganization.Id, item.Id, null, null).ToString("C");
                //Master.AddAttachmentLink("Payable Ledger " + apbalance, "~/company/accounting/ledger?ledgertype=Payable&id=" + item.Id.ToString(), "");
          }
//-------------------------------------------------------------------------------------------
          //protected void RequestW9(object sender, EventArgs e)
          //{
          //     MailMessage msg = new System.Net.Mail.MailMessage("Human Resources <humanresources@weavver.com>", "mitchel@weavver.com");
          //     msg.Subject = "W9 Form";

          //     string body = "Attached is your W9 form, please fill it out and return it.\r\n\r\n"
          //                 + "----------\r\n"
          //                 + "Weavver® Accounting";
          //     msg.Body = body;
          //     msg.IsBodyHtml = false;
          //     Attachment resumeAttachment = new Attachment(Server.MapPath("/Company/Accounting/Files/W-9 Blank.pdf"));
          //     resumeAttachment.Name = "W-9 Blank.pdf";
          //     msg.Attachments.Add(resumeAttachment);
          //     SmtpClient sClient = new SmtpClient(ConfigurationManager.AppSettings["smtp_server"], Int32.Parse(ConfigurationManager.AppSettings["smtp_port"]));
          //     sClient.Send(msg);
          //}
//-------------------------------------------------------------------------------------------
          public void Quit(string reason, DateTime finalDate)
          {
               //method description:
               // This page can be used if you plan on leaving the organization. Please allow two weeks notice if possible.<br /><br />

               // do lock out code

               // TerminationDate.Text = DateTime.Now.Add(TimeSpan.FromDays(14)).ToString("mm/dd/yy");
               // show balance
               
               //Thank you for working with us. We are sorry to see you go.<br />
               //Your current balance is $0.00. You will receive you last check, on blh blhablha.
          }
//-------------------------------------------------------------------------------------------
     }
}