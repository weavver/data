using System;

namespace Weavver.Data
{
//-------------------------------------------------------------------------------------------
     //[Flags]
    //public enum FilterAction
    //{
    //    /// <summary>
    //    /// Filter is never generated if not enabled.
    //    /// </summary>
    //    Enabled = 0x1,
    //    /// <summary>
    //    /// Hide Filter on page even if enabled.
    //    /// </summary>
    //    Hidden = 0x2,
    //    /// <summary>
    //    /// Show Filter but disable even it if enabled.
    //    /// </summary>
    //    Disabled = 0x4,
    //    /// <summary>
    //    /// Set Default value if enabled
    //    /// </summary>
    //    AutoDefault = 0x8,
    //}
//-------------------------------------------------------------------------------------------
    /// <summary>
    /// Actions a Column can 
    /// have assigned to itself.
    /// </summary>
    [Flags]
    public enum ColumnActions
    {
        /// <summary>
        /// Action on a column/property
        /// </summary>
        DenyRead = 1,
        /// <summary>
        /// Action on a column/property
        /// </summary>
        DenyWrite = 2,
    }
//-------------------------------------------------------------------------------------------
    /// <summary>
    /// Table permissions enum, allows different 
    /// levels of permission to be set for each 
    /// table on a per role bassis.
    /// </summary>
    [Flags]
    public enum TableView
    {
          /// <summary>
          /// List page
          /// </summary>
          List = 0x02,
          /// <summary>
          /// Showcase
          /// </summary>
          Showcase = 0x11,
          /// <summary>
          /// PressRoll
          /// </summary>
          PressRoll = 0x15,
          /// <summary>
          /// Comma deliminated list
          /// </summary>
          CSV = 0x14
     }
//-------------------------------------------------------------------------------------------
     [Flags]
     public enum RowView
     {
          /// Page page
          /// </summary>
          Page = 0x01,
          /// Details page
          /// </summary>
          Details = 0x02,
          /// <summary>
          /// Edit row
          /// </summary>
          Edit = 0x04,
          /// <summary>
          /// StoreItem
          /// </summary>
          StoreItem = 0x12
     }
//-------------------------------------------------------------------------------------------
     [Flags]
     public enum RowAction
     {
          /// <summary>
          /// Insert page
          /// </summary>
          Insert = 0x08,
          /// <summary>
          /// Delete operations
          /// </summary>
          Delete = 0x10,
          Update = 0x20
    }
//-------------------------------------------------------------------------------------------
}