using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.RatingModels;
using MiniUdemyWebAPI.Models.UserModels;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.Models.EnrollmentModels
{

    public enum EnrollmentStatus
    {
        Enrolled,
        Completed,
        Cancelled,
        Expired,
        Failed,
    }

    public class Enrollments
    {
        [Key]
        public int EnrollmentId { get; set; }



        [Required]
        public DateTime EnrollmentOn { get; set; } = DateTime.Now;

        [Required]
        public EnrollmentStatus Status { get; set; } = EnrollmentStatus.Enrolled;

        [Range(0, 100)]
        public int ProgressPercentage { get; set; } = 0;

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Purchase price must be a positive value.")]
        public decimal PurchasePrice { get; set; }

        [Required]
        public bool IsExpired { get; set; }=false;

        [Required]
        public DateTime PurchaseAt { get; set; } = DateTime.Now;

        //Course validity for students  for specifit students default values would according to course

        [Range(0, int.MaxValue)]
        public int Years { get; set; } = 0;

        [Range(0, 11)]
        public int Months { get; set; } = 0;

        [Range(0, 30)]
        public int Days { get; set; } = 0;



        public int UserId { get; set; }
        public User User { get; set; }


        public int CourseId { get; set; }
        public Course Course { get; set; }

        public Rating Rating { get; set; }

    }

}
