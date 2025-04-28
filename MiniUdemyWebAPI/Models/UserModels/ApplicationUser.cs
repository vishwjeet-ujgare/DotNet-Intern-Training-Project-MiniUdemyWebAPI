using Microsoft.AspNetCore.Identity;
using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using MiniUdemyWebAPI.Models.UserProfileModels;

namespace MiniUdemyWebAPI.Models.UserModels
{
    public class ApplicationUser : IdentityUser
    {


        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public UserProfile UserProfile { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
        // Navigation property for user roles
        public  ICollection<IdentityUserRole<string>> UserRoles { get; set; }

    }
}
