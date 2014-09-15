namespace Weavver.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KnowledgeBase")]
    public partial class KnowledgeBase
    {
        public KnowledgeBase()
        {
            KnowledgeBase1 = new HashSet<KnowledgeBase>();
        }

        public Guid Id { get; set; }

        public Guid OrganizationId { get; set; }

        public Guid? ParentId { get; set; }

        [StringLength(256)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string HtmlBody { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public int? Position { get; set; }

        public virtual ICollection<KnowledgeBase> KnowledgeBase1 { get; set; }

        public virtual KnowledgeBase KnowledgeBase2 { get; set; }
    }
}
