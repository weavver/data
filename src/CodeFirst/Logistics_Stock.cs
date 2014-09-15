namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Logistics_Stock
    {
        public Guid Id { get; set; }

        public Guid ShareId { get; set; }

        public Guid CompanyId { get; set; }

        public int TotalAvailable { get; set; }

        public Guid OwnedBy { get; set; }
    }
}
