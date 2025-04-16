using MiniUdemyWebAPI.Models.EnrollmentModels;
using MiniUdemyWebAPI.Models.UserModels;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.CourseModels
{
    public enum CourseStatus
    {
        Draft,
        Submitted,
        Published,
        Approved,
        Rejected,
       
      }

    public enum CourseLevels
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Headline { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Duration { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Fees { get; set; } = decimal.Zero;

        [Required]
        public CourseLevels Level { get; set; }

        [MaxLength(255)]
        public string ThumbnailUrl { get; set; }

        [Required]
        public CourseStatus Status { get; set; } = CourseStatus.Draft;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        //Course validity

        [Range(0, int.MaxValue)]
        public int Years { get; set; } = 0;

        [Range(0,11)]
        public int Months { get; set; } = 0;

        [Range(0, 30)]
        public int Days { get; set; } = 0;



        [Required]
        public int LanguageId { get; set; } // foreign key
        public Language Language { get; set; }


        public int CourseCategoryId { get; set; }   //foreign key
        public CourseCategory Category { get; set; }

        [Required]
        public int UserId { get; set; }  // foreign key for instructor only
        public User User { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
