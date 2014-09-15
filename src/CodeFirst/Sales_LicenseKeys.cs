namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_LicenseKeys
    {
        public Sales_LicenseKeys()
        {
            Sales_LicenseKeyActivations = new HashSet<Sales_LicenseKeyActivations>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? ProductId { get; set; }

        public Guid? AssignedTo { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        [StringLength(150)]
        public string Organization { get; set; }

        public int? ConcurrentUsers { get; set; }

        [Required]
        [StringLength(150)]
        public string Key { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public int MachineCount { get; set; }

        public int ConcurrentUsersPerMachine { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string ExtraXML { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int? Activations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations1 { get; set; }

        public virtual ICollection<Sales_LicenseKeyActivations> Sales_LicenseKeyActivations { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
