namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_RecurringBillables
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public Guid Service { get; set; }

        public Guid AccountFrom { get; set; }

        public Guid AccountTo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Memo { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime Position { get; set; }

        public DateTime? EndAt { get; set; }

        [StringLength(50)]
        public string BillingDirection { get; set; }

        [Required]
        [StringLength(50)]
        public string BillingPeriod { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? UnbilledPeriods { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? UnbilledAmount { get; set; }

        public virtual Logistics_Organizations AccountFromData { get; set; }

        public virtual Logistics_Organizations AccountToData { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual Logistics_Organizations OrganizationData { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
