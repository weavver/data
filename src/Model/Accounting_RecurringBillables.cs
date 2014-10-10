using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     public enum RecurringBillableStatus :  byte
     {
          Enabled,
          Disabled
     }
//-------------------------------------------------------------------------------------------
     public enum BillingDirectionEnum :  byte
     {
          [Description("Post-Bill")]
          PostBill,
          [Description("Pre-Bill")]
          PreBill
     }
//-------------------------------------------------------------------------------------------
     public enum BillingPeriodType :  byte
     {
          Monthly
     }
//-------------------------------------------------------------------------------------------
     [MetadataType(typeof(Accounting_RecurringBillables.Metadata))]
     [DisplayName("Recurring Billables")]
     [DataAccess(TableView.List, "Administrators", "Accountants", Width = 1254, Height = 850)]
     [DataAccess(RowView.Details, "Administrators", "Accountants", Width = 845, Height = 850)]
     [DataAccess(RowView.Edit, "Administrators", "Accountants", Width = 845, Height = 850)]
     [DataAccess(RowAction.Insert, "Administrators", "Accountants", Width = 845, Height = 850)]
     [DataAccess(RowAction.Delete, "Administrators", "Accountants", Width = 845, Height = 850)]
     partial class Accounting_RecurringBillables : IAuditable, IValidator, IRowStyle
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               //[DisplayFormat(DataFormatString = "{0:C}")]
               //public object Debits;

               [ScaffoldColumn(false)]
               public object OrganizationData;

               [Display(Name = "Status", Order = -4)]
               [EnumDataType(typeof(RecurringBillableStatus))]
               [UIHint("Enum")]
               public object Status;

               [Display(Name = "Direction", Order = -3)]
               [EnumDataType(typeof(BillingDirectionEnum))]
               [FilterUIHint("Enum")]
               [UIHint("Enum")]
               public object BillingDirection;

               [Display(Name = "Account From", Order = -1)]
               public object AccountFromData;

               [Display(Name = "Account To", Order = 0)]
               public object AccountToData;

               [Display(Name = "Billing Interval", Order = 3)]
               [EnumDataType(typeof(BillingPeriodType))]
               [UIHint("Enum")]
               public object BillingPeriod;

               [Display(Order = 4)]
               [UIHint("MultilineText")]
               public object Memo;

               [DisplayFormat(DataFormatString = "{0:C}")]
               [Display(Order = 5)]
               public object Amount;

               [Display(Name = "Start At", Order = 6)]
               public object StartAt;

               [Display(Name = "Position", Order = 7)]
               public object Position;

               [Display(Name="End At",Order = 8)]
               public object EndAt;

               [Display(Name = "Unbilled Periods", Order = 9)]
               [ScaffoldColumn(true)]
               public object UnbilledPeriods;

               [Display(Name = "Unbilled Balance", Order = 10)]
               [ScaffoldColumn(true)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object UnbilledAmount;

               //[FilterUIHint("DateTime")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Created At", Order = 11)]
               [ReadOnly(true)]
               public object CreatedAt;

               //[FilterUIHint("DateTime")]
               [Display(Name = "Updated At", Order = 20)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object UpdatedAt;

               [ReadOnly(true)]
               [Display(Name = "Created By")]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [Display(Name = "Updated By")]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users1;
//-------------------------------------------------------------------------------------------
          }
//-------------------------------------------------------------------------------------------
          public override string ToString()
          {
               return "ARB Rule";
          }
//-------------------------------------------------------------------------------------------
          public List<Accounting_LedgerItems> ProjectLedgerItems(int periods)
          {
               List<Accounting_LedgerItems> Items = new List<Accounting_LedgerItems>();
               for (int i = 0; i < periods; i++)
               {
                    Guid newId = Guid.NewGuid();
                    Accounting_LedgerItems item = new Accounting_LedgerItems
                    {
                         Id = newId,
                         OrganizationId = OrganizationId,
                         ExternalId = newId.ToString(),
                         PostAt = Position.AddMonths(i),
                         AccountId = (AccountFrom == OrganizationId) ? AccountTo : AccountFrom,
                         LedgerType = (AccountFrom == OrganizationId) ? LedgerType.Payable.ToString() : LedgerType.Receivable.ToString(),
                         Code = (AccountFrom == OrganizationId) ? CodeType.Purchase.ToString() : CodeType.Sale.ToString(),
                         Amount = Amount * -1.0m,
                         CreatedBy = Id,
                         UpdatedBy = Id
                    };

                    string timespan = "";
                    if (BillingDirection == BillingDirectionEnum.PreBill.ToString())
                    {
                         timespan = Position.ToLocalTime().AddMonths(i).ToString("MM/dd/yy") + " to " + Position.ToLocalTime().AddMonths(i + 1).ToString("MM/dd/yy");
                    }
                    else if (BillingDirection == BillingDirectionEnum.PostBill.ToString())
                    {
                         timespan = Position.ToLocalTime().AddMonths(i - 1).ToString("MM/dd/yy") + " to " + Position.ToLocalTime().AddMonths(i).ToString("MM/dd/yy");
                    }

                    if (Memo.Contains("%timespan%"))
                         item.Memo = Memo.Replace("%timespan%", timespan);
                    else
                         item.Memo = Memo + ", " + timespan;
                    Items.Add(item);
               }
               return Items;
          }
//-------------------------------------------------------------------------------------------
          public int BillAccount(Guid recurringBillableId)
          {
               using (WeavverEntityContainer data = new WeavverEntityContainer())
               {
                    Accounting_RecurringBillables billable = (from x in data.Accounting_RecurringBillables
                                                              where x.Id == recurringBillableId
                                                              select x).First();

                    if (billable.Status == "Enabled")
                    {
                         int unbilledPeriods = billable.UnbilledPeriods.Value;
                         var billables = billable.ProjectLedgerItems(unbilledPeriods);
                         foreach (var item in billables)
                         {
                              data.Accounting_LedgerItems.Add(item);
                         }
                         // we have to convert it to local time first! or there will have some weird bug where 11/01/11 goes to 11/30/11 instead of 12/01/11
                         billable.Position = billable.Position.ToLocalTime().AddMonths(unbilledPeriods).ToUniversalTime();

                         if (billable.EndAt.HasValue && billable.Position > billable.EndAt.Value)
                              billable.Status = "Disabled";

                         data.SaveChanges();
                         return billables.Count;
                    }
                    else
                    {
                         return 0;
                    }
               }
          }
////-------------------------------------------------------------------------------------------
          //TODO: ADD LEDGER TOTAL/BALNCE TO LINK
          //Total.Balance_ForLedger(LedgerType.Receivable, LoggedInUser.OrganizationId, item.AccountFrom, null, null).ToString("C");
          [DynamicDataWebMethod("Account Ledger", "Accountants")]
          public DynamicDataWebMethodReturnType ViewLedger()
          {
               string url = "~/Accounting_LedgerItems/List.aspx?AccountId={0}&LedgerType={1}";
               if (AccountFrom == OrganizationId)
               {
                    //string apbalance = Accounting.Balance_ForLedger(LedgerType.Payable, LoggedInUser.OrganizationId, item.AccountTo, null, null).ToString("C");
                    url = String.Format(url, AccountTo, LedgerType.Payable.ToString());
               }
               else
               {
                    //string arbalance = 
                    //Master.AddAttachmentLink("Receivables - " + arbalance, ");

                    url = String.Format(url, AccountFrom, LedgerType.Receivable.ToString());
               }

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.RedirectRequest = true;
               ret.RedirectURL = url;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          [DynamicDataWebMethod("Push Unbilled Items", "Administrators", "Accountants")]
          public DynamicDataWebMethodReturnType PushUnbilledItems()
          {
               int periodsBilled = BillAccount(Id);

               DynamicDataWebMethodReturnType ret = new DynamicDataWebMethodReturnType();
               ret.Status = "Account Billed";
               ret.Message = "Total periods billed: " + periodsBilled.ToString();

               ret.RefreshData = true;
               return ret;
          }
//-------------------------------------------------------------------------------------------
          public void Validate(out bool Valid, out string ErrorMessage)
          {
               if (Position < StartAt)
                    Position = StartAt;

               if (EndAt.HasValue && Position > EndAt.Value)
                    Status = "Disabled";

               // we strip out the time part of the datetime object and then convert it to the universal format
               // we don't need the time portion since billables are posted to the first moment of the day
               //StartAt = new DateTime(StartAt.Year, StartAt.Month, StartAt.Day, 0, 0, 0, 0, DateTimeKind.Local).ToUniversalTime();
               //Position = new DateTime(Position.Year, Position.Month, Position.Day, 0, 0, 0, 0, DateTimeKind.Local); // this is buggy
               //if (EndAt.HasValue)
               //     EndAt = new DateTime(EndAt.Value.Year, EndAt.Value.Month, EndAt.Value.Day, 0, 0, 0, 0, DateTimeKind.Local).ToUniversalTime();

               Valid = true;
               ErrorMessage = null;
          }
//-------------------------------------------------------------------------------------------
          public void GetRowStyle(out string cssNormal, out string cssHover)
          {
               cssNormal = "RowStyle";
               cssHover = "HoverRowStyle";

               var context = System.Web.HttpContext.Current;
               //if (item.AccountTo == LoggedInUser.OrganizationId)
               //(string) context.Session["SelectedOrganizationId"]
               if (AccountFrom == OrganizationId)
               {
                    cssNormal = "DebitRowStyle";
               }
               else
               {
                    cssNormal = "CreditRowStyle";
               }
          }
//-------------------------------------------------------------------------------------------
     }
}