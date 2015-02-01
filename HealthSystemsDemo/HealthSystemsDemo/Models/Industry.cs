namespace HealthSystemsDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Industry")]
    public partial class Industry
    {
        public Industry()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IndustryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
