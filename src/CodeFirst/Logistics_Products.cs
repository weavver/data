namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_Products
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        public string Brief { get; set; }

        public string Description { get; set; }

        public string BillingNotes { get; set; }

        [Column(TypeName = "money")]
        public decimal SetUp { get; set; }

        [Column(TypeName = "money")]
        public decimal Deposit { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitCost { get; set; }

        [StringLength(150)]
        public string URL { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitRetailPrice { get; set; }

        public bool IsLab { get; set; }

        [StringLength(15)]
        public string PluginURL { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public bool IsPublic { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitMonthly { get; set; }

        public bool UnlimitedInventory { get; set; }

        public bool AllowBackOrder { get; set; }

        public virtual Logistics_FeatureOptions Logistics_FeatureOptions { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
