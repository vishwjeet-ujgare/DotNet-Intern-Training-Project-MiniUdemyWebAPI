using MiniUdemyWebAPI.Models.UserProfileModels;

namespace MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users
{
    public interface IUserProfileAdminRepository
    {
         Task<UserProfile> GetUserProfileById(string userId);
    }
}
