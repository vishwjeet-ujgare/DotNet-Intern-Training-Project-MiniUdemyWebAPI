using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Helpers;
using MiniUdemyWebAPI.Models.UserModels;

namespace MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users
{
    public interface IUserAdminRepository
    {

        Task<PagedResult<ApplicationUser>> GetAllUsersAsync(UserQueryParameters parameters);
        Task<List<IdentityRole>> GetUserRolesByIdAsync(string userId);

        //Task<PagedResult<ApplicationUser>> GetUsersByRoleAsync(string roleName, UserQueryParameters parameters);
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<bool> CreateUserAsync(ApplicationUser user);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<bool> DeleteUserAsync(string userId);
    }
}
