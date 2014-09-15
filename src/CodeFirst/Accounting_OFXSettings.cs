namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_OFXSettings
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? AccountId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        public int FinancialInstitutionId { get; set; }

        [Required]
        [StringLength(50)]
        public string FinancialInstitutionName { get; set; }

        [StringLength(50)]
        public string BankId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        public bool? Enabled { get; set; }

        [Column(TypeName = "money")]
        public decimal? LedgerBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? AvailableBalance { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime? LastSuccessfulConnection { get; set; }

        public virtual Accounting_Accounts Accounting_Accounts { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
