using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.CourseModels
{
    public class CourseCategory
    {
        [Key]
        public int CourseCategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; } = string.Empty;

        public int? ParentCategoryId { get; set; }

        [ForeignKey("ParentCategoryId")]
        public CourseCategory? ParentCategory { get; set; }

         public ICollection<Course>? Courses { get; set; }
    }
}
