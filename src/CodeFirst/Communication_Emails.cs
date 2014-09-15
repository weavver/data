namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Communication_Emails
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(250)]
        public string From { get; set; }

        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        [Column(TypeName = "text")]
        public string Raw { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [Required]
        [StringLength(250)]
        public string To { get; set; }

        [Required]
        public string HTMLBody { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
