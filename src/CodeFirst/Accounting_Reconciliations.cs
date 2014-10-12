namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_Reconciliations
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid Account { get; set; }

        public DateTime StartAt { get; set; }

        public DateTime EndAt { get; set; }

        [Column(TypeName = "money")]
        public decimal StartingBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal EndingBalance { get; set; }

        [Column(TypeName = "money")]
        public decimal? Credits { get; set; }

        [Column(TypeName = "money")]
        public decimal? Debits { get; set; }

        [Column(TypeName = "money")]
        [ScaffoldColumn(false)]
        public decimal? EnteredStartingBalance { get; set; }

        [Column(TypeName = "money")]
        [ScaffoldColumn(false)]
        public decimal? EnteredDebits { get; set; }

        [Column(TypeName = "money")]
        [ScaffoldColumn(false)]
        public decimal? EnteredCredits { get; set; }

        [Column(TypeName = "money")]
        [ScaffoldColumn(false)]
        public decimal? EnteredEndingBalance { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Accounting_Accounts Accounting_Accounts { get; set; }
    }
}
