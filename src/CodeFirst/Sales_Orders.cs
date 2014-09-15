namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_Orders
    {
        public Guid Id { get; set; }

        public int? OrderNum { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [StringLength(125)]
        public string PrimaryContactEmail { get; set; }

        [StringLength(125)]
        public string PrimaryContactNameFirst { get; set; }

        [StringLength(125)]
        public string PrimaryContactNameLast { get; set; }

        [StringLength(125)]
        public string PrimaryContactOrganization { get; set; }

        [StringLength(125)]
        public string PrimaryContactPhoneNum { get; set; }

        [StringLength(125)]
        public string PrimaryContactPhoneExt { get; set; }

        [StringLength(125)]
        public string BillingContactEmail { get; set; }

        [StringLength(125)]
        public string BillingContactNameFirst { get; set; }

        [StringLength(125)]
        public string BillingContactNameLast { get; set; }

        [StringLength(125)]
        public string BillingContactOrganization { get; set; }

        [StringLength(125)]
        public string BillingContactPhoneNum { get; set; }

        [StringLength(125)]
        public string BillingContactPhoneExt { get; set; }

        [Column(TypeName = "text")]
        public string Cart { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public Guid? PrimaryContactAddress { get; set; }

        public Guid? BillingContactAddress { get; set; }

        public Guid? Orderee { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Total { get; set; }

        [HideColumnIn(PageTemplate.List)]
        public virtual Logistics_Addresses Logistics_Addresses { get; set; }

        [HideColumnIn(PageTemplate.List)]
        public virtual Logistics_Addresses Logistics_Addresses1 { get; set; }

        [HideColumnIn(PageTemplate.List)]
        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
