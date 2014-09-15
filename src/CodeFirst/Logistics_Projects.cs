namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_Projects
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(124)]
        public string Name { get; set; }

        [Required]
        [StringLength(250)]
        public string Brief { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(250)]
        public string URL { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
