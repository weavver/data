namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_DIDs
    {
        public Guid? Id { get; set; }

        public Guid? OrganizationId { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string number { get; set; }

        [Key]
        [Column(Order = 1)]
        public Guid userid { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public Guid? UpdatedBy { get; set; }
    }
}
