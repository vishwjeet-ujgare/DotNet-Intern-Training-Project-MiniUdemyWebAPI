using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.Models.UserModels
{
    public class UserRoles
    {
        [ Key]
        public int UserRoleId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        [Required]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    }
}
