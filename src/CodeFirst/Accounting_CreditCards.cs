namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Accounting_CreditCards
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(16)]
        public string Number { get; set; }

        [StringLength(50)]
        public string Issuer { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(75)]
        public string EmailAddress { get; set; }

        [StringLength(75)]
        public string AddressLine1 { get; set; }

        [StringLength(75)]
        public string AddressLine2 { get; set; }

        [StringLength(75)]
        public string State { get; set; }

        [StringLength(75)]
        public string ZipCode { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(15)]
        public string PhoneExtension { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }

        [Required]
        [StringLength(4)]
        public string SecurityCode { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
