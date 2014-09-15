namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IT_RemotePowerUnits
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(125)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Brand { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(75)]
        public string Host { get; set; }

        [Required]
        [StringLength(75)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
