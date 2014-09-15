namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Data_Links
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid Object1 { get; set; }

        [Required]
        [StringLength(125)]
        public string Object1Type { get; set; }

        public Guid Object2 { get; set; }

        [Required]
        [StringLength(125)]
        public string Object2Type { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
