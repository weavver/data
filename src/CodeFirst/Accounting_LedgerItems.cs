namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_LedgerItems
    {
        public Guid Id { get; set; }

        [StringLength(124)]
        public string ExternalId { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? AccountId { get; set; }

        [StringLength(50)]
        public string LedgerType { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(250)]
        public string Memo { get; set; }

        public DateTime? PostAt { get; set; }

        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }

        public Guid? Source { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public Guid? TransactionId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [StringLength(4000)]
        public string AccountName { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
