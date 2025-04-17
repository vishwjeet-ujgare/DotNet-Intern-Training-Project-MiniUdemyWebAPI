using MiniUdemyWebAPI.Models.EnrollmentModels;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.Course
{
    public class CourseAdminDto : CoursePublicDto
    {
        public enum CourseStatus
        {
            Draft,
            Submitted,
            Published,
            Approved,
            Rejected,
        }

        [Required]
        public CourseStatus Status { get; set; } = CourseStatus.Draft;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        //Course validity

        [Range(0, int.MaxValue)]
        public int Years { get; set; } = 0;

        [Range(0, 11)]
        public int Months { get; set; } = 0;

        [Range(0, 30)]
        public int Days { get; set; } = 0;


        public int CourseCategoryId { get; set; }   //foreign 
        public String Category { get; set; } // foreign key


        [Required]
        public int LanguageId { get; set; } // foreign key
        public string Language { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }



        public List<Enrollments> Enrollments { get; set; }
    }
}
