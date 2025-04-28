using Microsoft.AspNetCore.Identity;

namespace MiniUdemyWebAPI.DTO.Users
{
    public class UserRolesDTO
    {
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
