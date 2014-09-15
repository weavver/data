namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ShowAllTrigger
    {
        [Key]
        [Column(Order = 0)]
        public string trigger_name { get; set; }

        [StringLength(128)]
        public string trigger_owner { get; set; }

        [Key]
        [Column(Order = 1)]
        public string table_schema { get; set; }

        [StringLength(128)]
        public string table_name { get; set; }

        public int? isupdate { get; set; }

        public int? isdelete { get; set; }

        public int? isinsert { get; set; }

        public int? isafter { get; set; }

        public int? isinsteadof { get; set; }

        public int? disabled { get; set; }
    }
}
