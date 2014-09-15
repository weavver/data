namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Data_RowLookups
    {
        [Key]
        public Guid RowId { get; set; }

        [Required]
        [StringLength(125)]
        public string TableName { get; set; }
    }
}
