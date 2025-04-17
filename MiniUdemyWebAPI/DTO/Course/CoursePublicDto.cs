using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.Course
{
    public class CoursePublicDto
    {
        public enum CourseLevels
        {

            Beginner,
            Intermediate,
            Advanced,
            All_levels

        }



        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [Required]
        [MaxLength(255)]
        public string Headline { get; set; }

        [MaxLength(100)]
        public string Duration { get; set; }


        [MaxLength(255)]
        public string ThumbnailUrl { get; set; }

     
        [Required]
        public string Level { get; set; }


        [Required]
        [Range(0, double.MaxValue)]

        public decimal Fees { get; set; } = decimal.Zero;

        public int TotalRatingCount { get; set; }
        
        [Range(1, 5)]
        public float AvgRating { get; set; }
       

        [Required]
        public int UserId { get; set; } //foreign key
        public string UserName { get; set; }

    }
}
