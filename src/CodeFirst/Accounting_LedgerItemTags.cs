namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_LedgerItemTags
    {
        [Key]
        [Column(Order = 0)]
        public Guid Id { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid OrganizationId { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(250)]
        public string Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(250)]
        public string StartsWith { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
