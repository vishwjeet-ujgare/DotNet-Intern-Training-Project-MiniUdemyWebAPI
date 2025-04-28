using MiniUdemyWebAPI.Models.UserProfileModels;
using System.Diagnostics.Contracts;

namespace MiniUdemyWebAPI.DTO.Users
{
    public class UserBasicInfoDTO
    {
        public String Id { get; set; }
        public string? FirstName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        //public UserProfileBasicInfoDTO UserProfileBasicInfoDTO { get; set; }

        //public UserRolesDTO UserRolesDTO { get; set; }

    }
}
