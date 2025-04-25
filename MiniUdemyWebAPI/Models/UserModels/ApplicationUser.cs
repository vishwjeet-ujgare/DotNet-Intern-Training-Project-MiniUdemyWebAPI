using Microsoft.AspNetCore.Identity;
using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using MiniUdemyWebAPI.Models.UserProfileModels;

namespace MiniUdemyWebAPI.Models.UserModels
{
    public class ApplicationUser:IdentityUser
    {
        public UserProfile UserProfile { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Enrollments> Enrollments { get; set; }
    }
}
