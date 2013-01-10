using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Weavver.Utilities;

namespace Weavver.Data
{
     partial class CustomerService_Tickets : ICRON
     {
          public void RunCronTasks(CommandLineArguments args)
          {
               return;
               // We create a ticket if this was a support e-mail

               //CustomerService_Tickets ticket = new CustomerService_Tickets();
               //ticket.AssignedBy = Guid.Empty;
               //ticket.AssignedTo = Guid.Empty;
               //ticket.Email = m.Headers.From.Raw;
               //ticket.Source = "SMTP";
               //ticket.Subject = m.Headers.Subject;
               //ticket.Message = m.MessagePart.GetBodyAsText();
               //ticket.CreatedAt = m.Headers.Received[0].Date;
               //ticket.CreatedBy = Guid.Empty;
               //ticket.UpdatedAt = DateTime.UtcNow;
               //ticket.UpdatedBy = Guid.Empty;
               //if (ticket.Commit())
               //{
               //     client.DeleteMessage(i);
               //}
          }
     }
}


//WeavverDatabase db = new WeavverDatabase();
//db.InitAsMySQL(ConfigurationManager.AppSettings["osticket_connectionstring"]);
//MySql.Data.MySqlClient.MySqlCommand command = new MySqlCommand("select * from ticket where status='open' order by created desc", db.MySqlDB);

//DateTime searchMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 0, 0, 0, 0, DateTimeKind.Local);
//for (int i = -1; i < 24; i++)
//{
//     string sql = "SELECT count(*) FROM ticket t where dept_id=20 and created > ?createdMin and created < ?createdMax";
//     if (i > 0)
//     {
//          searchMonth = searchMonth.AddMonths(-1);
//     }
//     MySqlCommand ticketCount = new MySqlCommand(sql, db.MySqlDB);
//     //Response.Write(searchMonth.ToString("MM/dd/yyyy") + "<br />");
//     ticketCount.Parameters.AddWithValue("?createdMin", (i == -1) ? DateTime.MinValue.ToString("yyyy-MM-dd") : searchMonth.ToString("yyyy-MM-dd"));
//     ticketCount.Parameters.AddWithValue("?createdMax", (i == -1) ? DateTime.MaxValue.ToString("yyyy-MM-dd") : searchMonth.AddMonths(1).ToString("yyyy-MM-dd"));
//     string totalName = (i == -1) ? "Total" : searchMonth.ToString("MMMM") + " " + searchMonth.Year;
//     TotalTickets.Text += totalName + ": " + ticketCount.ExecuteScalar().ToString() + "<br />";
//}