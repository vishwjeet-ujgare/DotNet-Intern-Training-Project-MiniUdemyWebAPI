using MiniUdemyWebAPI.Models.EnrollmentModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.RatingModels
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }

        [Range(1,5)]
        public float Starts { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        public DateTime RatedOn { get; set; }
        public bool IsUpdated { get; set; } = false;

        public  int EnrollmentId { get; set; }
        public Enrollments Enrollment { get; set; }

    }
}
