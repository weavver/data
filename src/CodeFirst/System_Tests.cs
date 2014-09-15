namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class System_Tests
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [StringLength(75)]
        public string Path { get; set; }

        public int Revision { get; set; }

        public int TestRun { get; set; }

        [Required]
        public string Log { get; set; }

        public int Duration { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
