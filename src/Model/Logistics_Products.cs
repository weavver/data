using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Weavver.Data
{
     [MetadataType(typeof(Logistics_Products.Metadata))]
     [DisplayColumn("Name", "Name", false)]
     [DisplayName("Products")]
     [DataAccess(TableView.Showcase, "Administrators", "Guest")]
     [DataAccess(TableView.List, "Administrators")]
     [DataAccess(RowView.Edit, "Administrators")]
     [DataAccess(RowView.Details, "Administrators")]
     [DataAccess(RowView.StoreItem, "Administrators", "Guest")]
     [DataAccess(RowAction.Delete, "Administrators")]
     [DataAccess(RowAction.Insert, "Administrators")]
     [DataAccess(TableView.CSV, "Administrators")]     
     partial class Logistics_Products : IAuditable
     {
          public class Metadata
          {
               [ScaffoldColumn(false)]
               public object Id;

               [Display(GroupName = "Test", Order = 1)]
               [FilterUIHint("String")]
               public object Name;

               //[Display(Name = "Features", Order = 2)]
               //[DisplayFormat(DataFormatString = "View")]
               //[HideColumnIn(PageTemplate.List)]
               //public object Logistics_Features;

               [ColumnGroup("Marketing")]
               [Display(Order = 10)]
               [FilterUIHint("String")]
               [UIHint("Code")]
               public object Brief;

               [ColumnGroup("Marketing")]
               [Display(Name="Details", Order = 15)]
               [HideColumnIn(PageTemplate.List)]
               [UIHint("Code")]
               public object Description;

               [ColumnGroup("Financials")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name="Billing Notes", Order = 20)]
               [UIHint("Code")]
               public object BillingNotes;

               [ColumnGroup("Financials")]
               [Display(Order = 25)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object Deposit;

               [ColumnGroup("Financials")]
               [Display(Name = "Set Up", Order = 30)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object SetUp;

               [ColumnGroup("Financials")]
               [Display(Name="Unit Cost",Order = 40)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object UnitCost;

               [ColumnGroup("Financials")]
               [Display(Name = "Retail Price", Order = 45)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object UnitRetailPrice;

               [ColumnGroup("Financials")]
               [Display(Name = "Monthly", Order = 50)]
               [DisplayFormat(DataFormatString = "{0:C}")]
               public object UnitMonthly;

               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Is Lab", Order = 13)]
               public object IsLab;

               [Display(Name = "Allow Backorder", Order = 14)]
               [HideColumnIn(PageTemplate.List)]
               public object AllowBackOrder;

               [Display(Name = "Unlimited Inventory", Order = 15)]
               [HideColumnIn(PageTemplate.List)]
               public object UnlimitedInventory;
               
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Is Public", Order = 16)]
               public object IsPublic;

               [ColumnGroup("Advanced")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Name = "Plugin URL", Order = 14)]
               public object PluginURL;

               [ColumnGroup("Advanced")]
               [HideColumnIn(PageTemplate.List)]
               [Display(Order = 25)]
               public object URL;

               [HideColumnIn(PageTemplate.List)]
               public object Logistics_FeatureOptions;

               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               [Display(Name = "Created At", Order = 30)]
               public object CreatedAt;

               [Display(Name = "Created By", Order=31)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users;

               [SecureColumn(ColumnActions.DenyWrite)]
               [HideColumnIn(PageTemplate.List)]
               [ReadOnly(true)]
               [Display(Name = "Updated At", Order = 32)]
               public object UpdatedAt;

               [Display(Name = "Updated By", Order = 33)]
               [ReadOnly(true)]
               [HideColumnIn(PageTemplate.List)]
               public object System_Users1;

               [ReadOnly(true)]
               [ScaffoldColumn(false)]
               public object Logistics_Organizations;
          }
     }
}