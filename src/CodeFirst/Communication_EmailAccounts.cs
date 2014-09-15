namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Communication_EmailAccounts
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(10)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Host { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        public DateTime? LastImport { get; set; }

        public DateTime? LastImportAttempt { get; set; }

        public int Port { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
