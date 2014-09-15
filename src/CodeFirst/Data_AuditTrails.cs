namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Data_AuditTrails
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        [StringLength(50)]
        public string TableName { get; set; }

        [StringLength(1)]
        public string Actions { get; set; }

        [Column(TypeName = "xml")]
        public string OldData { get; set; }

        [Column(TypeName = "xml")]
        public string NewData { get; set; }

        [StringLength(1000)]
        public string ChangedColumns { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }
    }
}
