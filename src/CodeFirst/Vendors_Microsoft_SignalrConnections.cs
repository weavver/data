namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Vendors_Microsoft_SignalrConnections
    {
          [Key]
        public Guid OrganizationId { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Node { get; set; }

        public Guid ConnectionId { get; set; }

        [MaxLength]
        public string UserAgent { get; set; }

        public bool Connected { get; set; }

        public DateTime ConnectedAt { get; set; }
    }
}
