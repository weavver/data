namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerService_Tickets
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(10)]
        public string ContactNumber { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [StringLength(124)]
        public string EmailAddress { get; set; }

        [StringLength(256)]
        public string Subject { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public Guid? AssignedTo { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations1 { get; set; }
    }
}
