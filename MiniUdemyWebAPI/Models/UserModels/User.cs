using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using MiniUdemyWebAPI.Models.UserProfileModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniUdemyWebAPI.Models.UserModels
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }


        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }


        [Required]
        [EmailAddress]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public bool IsActive { get; set; } = true;

        public bool IsDeleted { get; set; } = false;



        //Navigation properties

        public ICollection<Course> Courses { get; set; }

        public UserProfile UserProfile { get; set; }

        public ICollection<UserRoles> UserRoles  { get; set; }

        public ICollection<Enrollments> Enrollments { get; set; } 


    }
}
