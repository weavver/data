namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_AccountBalances
    {
        public Guid? OrganizationId { get; set; }

        public Guid? AccountId { get; set; }

        [StringLength(50)]
        public string LedgerType { get; set; }

        [StringLength(4000)]
        public string AccountName { get; set; }

        [Key]
        [Column(TypeName = "money")]
        public decimal Balance { get; set; }
    }
}
