namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IT_DownloadLogs
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(125)]
        public string FileName { get; set; }

        public DateTime DownloadedAt { get; set; }

        [Required]
        [StringLength(125)]
        public string DownloadedByIP { get; set; }

        public Guid DownloadedBy { get; set; }
    }
}
