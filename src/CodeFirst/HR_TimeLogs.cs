namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_TimeLogs
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid PersonId { get; set; }

        public DateTime Start { get; set; }

        public DateTime? End { get; set; }

        public string Memo { get; set; }

        public Guid? BillTo { get; set; }

        public Guid? CommissionedBy { get; set; }

        [Column(TypeName = "money")]
        public decimal? Earned { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? Duration { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }
    }
}
