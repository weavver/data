namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Jobs
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(125)]
        public string Title { get; set; }

        [Required]
        [StringLength(125)]
        public string Location { get; set; }

        public string Compensation { get; set; }

        public string Description { get; set; }

        public string Requirements { get; set; }

        public string Responsibilities { get; set; }

        public string Bonus { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
