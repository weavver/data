namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_Leads
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(150)]
        public string Source { get; set; }

        public Guid? InventoryItemId { get; set; }

        [StringLength(125)]
        public string EmailAddress { get; set; }

        [StringLength(125)]
        public string FirstName { get; set; }

        [StringLength(125)]
        public string LastName { get; set; }

        [StringLength(125)]
        public string ContactNumber { get; set; }

        public Guid? Organization { get; set; }

        [StringLength(125)]
        public string OrganizationSize { get; set; }

        [StringLength(125)]
        public string Website { get; set; }

        public string Notes { get; set; }

        public bool? ContactRequested { get; set; }

        [StringLength(125)]
        public string ReferredBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
