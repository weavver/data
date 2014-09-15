using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(System_Tests.Metadata))]
     [DisplayColumn("Path", "Path", false)]
     [DisplayName("Tests")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     partial class System_Tests : IAuditable, INotifyPropertyChanged, INotifyPropertyChanging
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [FilterUIHint("DateTime")]
               [ReadOnly(true)]
               [Display(Name = "Created At")]
               public object CreatedAt;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [ReadOnly(true)]
               public object CreatedBy;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [FilterUIHint("DateTime")]
               [Display(Name = "Updated At")]
               [ReadOnly(true)]
               public object UpdatedAt;

               [HideColumnIn(Weavver.Data.PageTemplate.List)]
               [ReadOnly(true)]
               public object UpdatedBy;
          }
//-------------------------------------------------------------------------------------------
          private DateTime? lastRunDateTime;
          private DateTime? startDateTime;
          private DateTime? endDateTime;

          public DateTime? LastRunDateTime
          {
               get
               {
                    return lastRunDateTime;
               }
               set
               {
                    OnPropertyChanging("LastRunDateTime");
                    lastRunDateTime = value;
                    OnPropertyChanged("LastRunDateTime");
                    OnPropertyChanged("LastRun");
               }
          }
//-------------------------------------------------------------------------------------------
          public DateTime? StartDateTime
          {
               get
               {
                    return startDateTime;
               }
               set
               {
                    OnPropertyChanging("StartDateTime");
                    startDateTime = value;
                    OnPropertyChanged("StartDateTime");
                    OnPropertyChanged("LastRun");
               }
          }
//-------------------------------------------------------------------------------------------
          public DateTime? EndDateTime
          {
               get
               {
                    return endDateTime;
               }
               set
               {
                    OnPropertyChanging("EndDateTime");
                    endDateTime = value;
                    OnPropertyChanged("EndDateTime");
                    OnPropertyChanged("LastRun");
               }
          }
//-------------------------------------------------------------------------------------------
          public string LastRun
          {
               get
               {
                    if (LastRunDateTime.HasValue)
                         return Weavver.Utilities.DateTimeHelper.GetFriendlyDateString(LastRunDateTime);
                    else
                         return "";
               }
          }
//-------------------------------------------------------------------------------------------
          public string RunTime
          {
               get
               {
                    if (!StartDateTime.HasValue)
                         return "";

                    TimeSpan runTime;

                    if (EndDateTime.HasValue)
                         runTime = EndDateTime.Value.Subtract(StartDateTime.Value);
                    else
                         runTime = DateTime.UtcNow.Subtract(StartDateTime.Value);

                    return Convert.ToInt32(runTime.TotalSeconds).ToString() + " second(s)";
               }
          }

          public bool IsStagingTest { get; set; }
//-------------------------------------------------------------------------------------------
          //[DynamicDataWebMethod("Test URL", "Administrators")]
          //public DynamicDataWebMethodReturnType Receivables()
          //{
          //     DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
          //     ret.RedirectRequest = true;
          //     // real url = String.Format("~/{0}/{1}.aspx?Id={2}", TableName, PageTemplate, ObjectId.ToString());
          //     ret.RedirectURL = Path;
          //     return ret;
          //}
//-------------------------------------------------------------------------------------------
          public void WriteLog(string message)
          {
               Console.WriteLine(message);
               Log += message;
          }
//-------------------------------------------------------------------------------------------
          public event PropertyChangedEventHandler PropertyChanged;

          public event PropertyChangingEventHandler PropertyChanging;

          // Create the OnPropertyChanged method to raise the event 
          protected void OnPropertyChanged(string name)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null)
               {
                    handler(this, new PropertyChangedEventArgs(name));
               }
          }

          // Create the OnPropertyChanging method to raise the event 
          protected void OnPropertyChanging(string name)
          {
               PropertyChangingEventHandler handler = PropertyChanging;
               if (handler != null)
               {
                    handler(this, new PropertyChangingEventArgs(name));
               }
          }
     }
}