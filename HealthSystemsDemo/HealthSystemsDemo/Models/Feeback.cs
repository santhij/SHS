using System.ComponentModel;

namespace HealthSystemsDemo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Display(AutoGenerateField = false)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        //[Required]
           [Display(AutoGenerateField = false)]
        [StringLength(10)]

        public string UserId { get; set; }
        
        
        [DisplayName("In what industry does your company operate?")]
        public int IndustryId { get; set; }

         [DisplayName("What is the main feature you use from our site?")]
        [StringLength(255)]
        public string MainFeature { get; set; }

         [DisplayName("How would you rate your experience using our services?")]
        public int ServiceRating { get; set; }

         [DisplayName("Is there anything you would like us to improve?")]
        [StringLength(255)]
        public string AreaOfImprovement { get; set; }

         [DisplayName("Do you have any further feedback that you'd like to share with us?")]
        [StringLength(255)]
        public string FurtherFeedback { get; set; }

        public virtual Industry Industry { get; set; }
    }
}
