namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sales_ShoppingCartItems
    {
        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public bool RequiresOrganizationId { get; set; }

        [StringLength(24)]
        public string SessionId { get; set; }

        public Guid ProductId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? OrderId { get; set; }

        [StringLength(128)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitCost { get; set; }

        public decimal SetUp { get; set; }

        public decimal Deposit { get; set; }

        public decimal Monthly { get; set; }

        [StringLength(256)]
        public string BackLink { get; set; }

        [Column(TypeName = "text")]
        public string Notes { get; set; }

        [Column(TypeName = "xml")]
        public string ExtraXML { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? Total { get; set; }

        public virtual System_Users System_Users { get; set; }

        public virtual System_Users System_Users1 { get; set; }
    }
}
