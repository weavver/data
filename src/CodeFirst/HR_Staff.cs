namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HR_Staff
    {
        public HR_Staff()
        {
            Sales_Resellers = new HashSet<Sales_Resellers>();
            HR_Tasks = new HashSet<HR_Tasks>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(75)]
        public string FirstName { get; set; }

        [StringLength(75)]
        public string MiddleName { get; set; }

        [StringLength(75)]
        public string LastName { get; set; }

        [StringLength(100)]
        public string EmailAddress { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(10)]
        public string PassCode { get; set; }

        public int? PersonalDays { get; set; }

        public int? SickDays { get; set; }

        public bool? IsSalaried { get; set; }

        [StringLength(75)]
        public string Status { get; set; }

        [StringLength(100)]
        public string Position { get; set; }

        [StringLength(75)]
        public string Location { get; set; }

        [Column(TypeName = "text")]
        public string Bio { get; set; }

        [Column(TypeName = "money")]
        public decimal? HourlyWage { get; set; }

        [Column(TypeName = "money")]
        public decimal? MonthlyBudget { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [StringLength(15)]
        public string Extension { get; set; }

        public virtual Logistics_Organizations Logistics_Organizations { get; set; }

        public virtual ICollection<Sales_Resellers> Sales_Resellers { get; set; }

        public virtual ICollection<HR_Tasks> HR_Tasks { get; set; }
    }
}
