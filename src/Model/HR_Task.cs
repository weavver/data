using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(HR_Task.Metadata))]
     [DisplayName("Tasks")]
     [DataAccess(TableView.List, "Administrators", "Employee")]
     [DataAccess(RowView.Edit, "Administrators", "Employee")]
     [DataAccess(RowView.Details, "Administrators", "Employee")]
     [DataAccess(RowAction.Delete, "Administrators", "Employee")]
     [DataAccess(RowAction.Insert, "Administrators", "Employee")]
     partial class HR_Task : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [ScaffoldColumn(false)]
               public object HR_Tasks1;

               [ScaffoldColumn(false)]
               [Display(Name = "Parent Task", Order = 1)]
               //[FilterUIHint("String")]
               [HideColumnIn(PageTemplate.List)]
               public object HR_Tasks2;

               [Display(Name = "Assigned To", Order = 2)]
               public object HR_Staff;

               [Display(Order = 2)]
               public object Status;

               [Display(Name="Assigned To", Order = 3)]
               //[FilterUIHint("String")]
               public object AssignedTo;

               //[HideColumnIn(PageTemplate.List)]
               [Display(Name = "Brief", Order = 4)]
               [FilterUIHint("String")]
               public object Name;

               [FilterUIHint("String")]
               [UIHint("Code")]
               [Display(Name = "Details", Order = 5)]
               [HideColumnIn(PageTemplate.List)]
               public object Description;

               [Display(Name = "Due By", Order = 6)]
               public object DueAt;

               [ScaffoldColumn(false)]
               [Display(Name = "Priority", Order = 7)]
               public object Priority;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Time Estimate", Order = 8)]
               public object TimeEstimate;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Time Max", Order = 9)]
               public object TimeMax;

               [DisplayFormat(DataFormatString = "{0:C}")]
               [Display(Name = "Bounty", Order = 10)]
               [ScaffoldColumn(false)]
               public object CostBudget;

               [DataType(DataType.Date)]
               [ScaffoldColumn(false)]
               [Display(Name = "Completed At", Order = 11)]
               [ReadOnly(true)]
               public object CompletedAt;

               [HideColumnIn(PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Created At", Order = 30)]
               [ReadOnly(true)]
               public object CreatedAt;

               [Display(Name = "Created By", Order = 31)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At", Order = 32)]
               [ReadOnly(true)]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name = "Updated By", Order = 33)]
               public object System_Users1;
          }
     }
//-------------------------------------------------------------------------------------------
     public enum HR_TaskStatus
     {
          Open,
          Closed,
          Suggested
     }     
//-------------------------------------------------------------------------------------------
     //// change order logic:
     //private void SwapSpots(Task taskA, Task taskB)
     //{
     //     int posA = taskA.Priority;
     //     taskA.Priority = taskB.Priority;
     //     taskB.Priority = posA;
     //     taskA.Commit();
     //     taskB.Commit();

     //     // example of moving object 2 to position 3 -- only 1 position change at a time
     //     // pos1 - obj1        pos1 - obj1
     //     // pos2 - obj2        pos2 - obj3
     //     // pos3 - obj3        pos3 - obj2
     //     // pos4 - obj4        pos4 - obj4
     //     // pos5 - obj5        pos5 - obj5

     //     // get whatever is next after the oldpriority and add/subtract from it
     //     // get whatever is in the 

     //     // select * from hr_tasks newpriority where position>=6 limit 1


     //     // This method is only useful if manually setting the Priority number, otherwise the record is just trading spots with another one!
     //     // UPDATE HumanResources_Tasks SET Priority = Priority - 1 WHERE Priority < newPriority;
     //     // UPDATE HumanResources_Tasks SET Priority = Priority + 1 WHERE Priority > newPriority;
     //}
     //// to move one up
}