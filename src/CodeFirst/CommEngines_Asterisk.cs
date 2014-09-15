namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CommEngines_Asterisk
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Host { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime UpdatedBy { get; set; }
    }
}
