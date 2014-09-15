namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_Checks
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(75)]
        public string Status { get; set; }

        public int CheckNumber { get; set; }

        public DateTime PostAt { get; set; }

        public Guid Payee { get; set; }

        public string PayeeName { get; set; }

        public Guid AccountId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(250)]
        public string Memo { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [StringLength(75)]
        public string ExternalId { get; set; }

        public virtual Accounting_Accounts Accounting_Accounts { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations1 { get; set; }
    }
}
