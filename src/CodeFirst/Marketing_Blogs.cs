namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Marketing_Blogs
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? PersonId { get; set; }

        [StringLength(125)]
        public string Title { get; set; }

        public string Body { get; set; }

        [StringLength(125)]
        public string Status { get; set; }

        public DateTime? PublishAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
