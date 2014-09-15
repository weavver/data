namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Applications
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(75)]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string Department { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFirst { get; set; }

        [Required]
        [StringLength(50)]
        public string NameLast { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string CoverLetter { get; set; }

        [Required]
        [StringLength(255)]
        public string ResumePath { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
