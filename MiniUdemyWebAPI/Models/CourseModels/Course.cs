using System;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.Models.CourseModels
{
    public enum CourseStatus
    {
        Draft,
        Published,
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
        public int CourseId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [MaxLength(100)]
        public string Duration { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Fees { get; set; } = decimal.Zero;

        [Required]
        public CourseLevels Level { get; set; }

        [MaxLength(50)]
        public string ThumbnailUrl { get; set; }

        [Required]
        public CourseStatus Status { get; set; } = CourseStatus.Draft;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;




        [Range(0, int.MaxValue)]
        public int Years { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int Months { get; set; } = 0;

        [Range(0, int.MaxValue)]
        public int Days { get; set; } = 0;



        [Required]
        public int LanguageId { get; set; }
    }
}
