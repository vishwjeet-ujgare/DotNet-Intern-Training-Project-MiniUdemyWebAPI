using MiniUdemyWebAPI.DTO.Users;
using MiniUdemyWebAPI.Helpers;

namespace MiniUdemyWebAPI.Services.Admin.Users
{
    public interface IUserAdminService
    {
         Task<List<UserBasicInfoDTO>> GetAllUsersAsync(UserQueryParameters userQueryParameters);
        //Task<UserBasicInfoDTO> GetUserByIdAsync(string id);
        //Task<bool> UpdateUserAsync(string id, UserBasicInfoDTO user);
        //Task<bool> DeleteUserAsync(string id);
        //Task<bool> ChangeUserStatusAsync(string id, bool isActive);
        //Task<bool> ChangeUserRoleAsync(string id, string role);
    }
}
