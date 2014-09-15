namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_FeatureOptions
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid ParentId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string BillingType { get; set; }

        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Logistics_Products Logistics_Products { get; set; }
    }
}
