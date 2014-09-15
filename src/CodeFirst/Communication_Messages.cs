namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Communication_Messages
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid Account { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Body { get; set; }

        public bool? ShowInStream { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
