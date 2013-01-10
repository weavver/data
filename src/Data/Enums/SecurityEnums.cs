using System;

namespace Weavver.Data
{
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

    /// <summary>
    /// Table permissions enum, allows different 
    /// levels of permission to be set for each 
    /// table on a per role bassis.
    /// </summary>
    [Flags]
    public enum TableActions
    {
        /// <summary>
        /// Default no permissions
        /// </summary>
        None = 0x00,
        /// <summary>
        /// Details page
        /// </summary>
        Details = 0x01,
        /// <summary>
        /// List page
        /// </summary>
        List = 0x02,
        /// <summary>
        /// List Details page
        /// </summary>
        ListDetails = 0x03,
        /// <summary>
        /// Edit page
        /// </summary>
        Edit = 0x04,
        /// <summary>
        /// Insert page
        /// </summary>
        Insert = 0x08,
        /// <summary>
        /// Delete operations
        /// </summary>
        Delete = 0x10,
        /// <summary>
        /// Showcase
        /// </summary>
        Showcase = 0x11,
        /// <summary>
        /// PressRoll
        /// </summary>
        PressRoll = 0x15,
        /// <summary>
        /// StoreItem
        /// </summary>
        StoreItem = 0x12,
        /// <summary>
        /// StoreItem
        /// </summary>
        Page = 0x13,
        
         CSV = 0x14
    }
}