namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendors_PayPal_IPNs
    {
        public Guid Id { get; set; }

        public Guid? OrganizationId { get; set; }

        [StringLength(125)]
        public string TxnId { get; set; }

        [StringLength(125)]
        public string TxnType { get; set; }

        [StringLength(125)]
        public string ReceiverEmail { get; set; }

        [StringLength(125)]
        public string ItemName { get; set; }

        [StringLength(125)]
        public string ItemNumber { get; set; }

        public int? Quantity { get; set; }

        [StringLength(125)]
        public string Invoice { get; set; }

        [StringLength(125)]
        public string Custom { get; set; }

        [StringLength(125)]
        public string PaymentStatus { get; set; }

        [StringLength(125)]
        public string PendingReason { get; set; }

        public DateTime? PaymentDate { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaymentFee { get; set; }

        [Column(TypeName = "money")]
        public decimal? PaymentGross { get; set; }

        [StringLength(125)]
        public string FirstName { get; set; }

        [StringLength(125)]
        public string LastName { get; set; }

        [StringLength(125)]
        public string AddressStreet { get; set; }

        [StringLength(125)]
        public string AddressCity { get; set; }

        [StringLength(125)]
        public string AddressState { get; set; }

        [StringLength(125)]
        public string AddressZip { get; set; }

        [StringLength(125)]
        public string AddressCountry { get; set; }

        [StringLength(125)]
        public string AddressStatus { get; set; }

        [StringLength(125)]
        public string PayerEmail { get; set; }

        [StringLength(125)]
        public string PayerStatus { get; set; }

        [StringLength(125)]
        public string PaymentType { get; set; }

        [StringLength(125)]
        public string NotifyVersion { get; set; }

        [StringLength(125)]
        public string VerifySign { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
