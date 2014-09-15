namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_Accounts
    {
        public Accounting_Accounts()
        {
            Accounting_Accounts1 = new HashSet<Accounting_Accounts>();
            Accounting_Checks = new HashSet<Accounting_Checks>();
            Accounting_OFXSettings = new HashSet<Accounting_OFXSettings>();
            Accounting_Reconciliations = new HashSet<Accounting_Reconciliations>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(50)]
        public string AccountNumber { get; set; }

        [Required]
        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string LedgerType { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Balance { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? AvailableBalance { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual ICollection<Accounting_Accounts> Accounting_Accounts1 { get; set; }

        public virtual Accounting_Accounts Accounting_Accounts2 { get; set; }

        public virtual ICollection<Accounting_Checks> Accounting_Checks { get; set; }

        public virtual ICollection<Accounting_OFXSettings> Accounting_OFXSettings { get; set; }

        public virtual ICollection<Accounting_Reconciliations> Accounting_Reconciliations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations1 { get; set; }
    }
}
