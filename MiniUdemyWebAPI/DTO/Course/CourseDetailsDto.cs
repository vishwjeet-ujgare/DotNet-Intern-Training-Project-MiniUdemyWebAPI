using MiniUdemyWebAPI.DTO.EnrollmentDtos;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.Course
{
    public class CourseDetailsDto:CourseCardDto
    {

        [MaxLength(1000)]
        public string Description { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        [Required]
        public int LanguageId { get; set; } // foreign key
        public string Language { get; set; }

        public int TotalEnrollments { get; set; }
        public EnrollmentPublicDto EnrollmentPublicDto { get; set; }

    }
}
