namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_Addresses
    {
        public Logistics_Addresses()
        {
            Sales_Orders = new HashSet<Sales_Orders>();
            Sales_Orders1 = new HashSet<Sales_Orders>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(75)]
        public string Name { get; set; }

        [Required]
        [StringLength(75)]
        public string Line1 { get; set; }

        [StringLength(75)]
        public string Line2 { get; set; }

        [Required]
        [StringLength(75)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        [Required]
        [StringLength(50)]
        public string ZipCode { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual ICollection<Sales_Orders> Sales_Orders { get; set; }

        public virtual ICollection<Sales_Orders> Sales_Orders1 { get; set; }
    }
}
