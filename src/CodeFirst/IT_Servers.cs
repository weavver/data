namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IT_Servers
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid ManagedBy { get; set; }

        public Guid ProvisionedTo { get; set; }

        [Required]
        [StringLength(50)]
        public string ServerName { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(12)]
        public string MAC { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
