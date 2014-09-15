namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_Discounts
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid ResellerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Scope { get; set; }

        public Guid ScopeItem { get; set; }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [Column(TypeName = "money")]
        public decimal AmountOffRetail { get; set; }

        public decimal PercentOffRetail { get; set; }

        public DateTime ExpiresAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual Sales_Resellers Sales_Resellers { get; set; }
    }
}
