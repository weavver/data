namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_Resellers
    {
        public Sales_Resellers()
        {
            Sales_Discounts = new HashSet<Sales_Discounts>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid ClientId { get; set; }

        public Guid Manager { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public virtual HR_Staff HR_Staff { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations1 { get; set; }

        public virtual ICollection<Sales_Discounts> Sales_Discounts { get; set; }
    }
}
