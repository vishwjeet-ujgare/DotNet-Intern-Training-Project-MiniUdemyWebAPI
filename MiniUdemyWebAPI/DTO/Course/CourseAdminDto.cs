﻿using MiniUdemyWebAPI.Models.EnrollmentModels;
using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.DTO.Course
{
    public class CourseAdminDto:CoursePublicDto
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
            Advanced,
            All_levels
        }

        [Required]
        public CourseLevels Level { get; set; }

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

        public List<Enrollments> Enrollments { get; set; }
    }
}
