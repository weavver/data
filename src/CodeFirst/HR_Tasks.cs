namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Tasks
    {
        public HR_Tasks()
        {
            HR_Tasks1 = new HashSet<HR_Tasks>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        public string Description { get; set; }

        public int? Priority { get; set; }

        [Column(TypeName = "money")]
        public decimal CostBudget { get; set; }

        public decimal TimeEstimate { get; set; }

        public decimal TimeMax { get; set; }

        public DateTime DueAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public Guid? AssignedTo { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid? ParentTask { get; set; }

        public virtual HR_Staff HR_Staff { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual ICollection<HR_Tasks> HR_Tasks1 { get; set; }

        public virtual HR_Tasks HR_Tasks2 { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
