namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IT_WebTraffic
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Object { get; set; }

        [Required]
        [StringLength(255)]
        public string RequestorIP { get; set; }

        public DateTime AccessedAt { get; set; }

        [Required]
        [StringLength(255)]
        public string ReferrerUrl { get; set; }

        [Required]
        [StringLength(255)]
        public string UserAgent { get; set; }
    }
}
