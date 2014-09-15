namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CMS_Pages
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(128)]
        public string MasterPage { get; set; }

        [Required]
        [StringLength(256)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Page { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
