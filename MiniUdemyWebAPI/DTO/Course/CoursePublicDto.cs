using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.Course
{
    public class CoursePublicDto
    {


        [Key]
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


        [MaxLength(255)]
        public string ThumbnailUrl { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Fees { get; set; } = decimal.Zero;



        [Required]
        public int LanguageId { get; set; } // foreign key
        public string Language { get; set; }

        public int CourseCategoryId { get; set; }   //foreign 
        public String Category{get; set;
        }
    }
}
