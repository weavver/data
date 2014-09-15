namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_LicenseKeyActivations
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid LicenseKeyId { get; set; }

        [Required]
        [StringLength(50)]
        public string MachineCode { get; set; }

        public DateTime LastHeardFrom { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual Sales_LicenseKeys Sales_LicenseKeys { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
