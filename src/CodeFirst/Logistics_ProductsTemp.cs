namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_ProductsTemp
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid OrganizationId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Brief { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Description { get; set; }

        [StringLength(250)]
        public string URL { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "money")]
        public decimal UnitCost { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "money")]
        public decimal UnitPrice { get; set; }

        [Key]
        [Column(Order = 7)]
        public bool AllowBackorder { get; set; }

        [Key]
        [Column(Order = 8)]
        public bool UnlimitedInventory { get; set; }

        [Key]
        [Column(Order = 9)]
        public DateTime CreatedAt { get; set; }

        [Key]
        [Column(Order = 10)]
        public Guid CreatedBy { get; set; }

        [Key]
        [Column(Order = 11)]
        public DateTime UpdatedAt { get; set; }

        [Key]
        [Column(Order = 12)]
        public Guid UpdatedBy { get; set; }
    }
}
