using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.Models.UserProfileModels;
using MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users;


namespace MiniUdemyWebAPI.Repositories.Implementations.Admin.User
{
    public class UserProfileAdminRepository : IUserProfileAdminRepository
    {
        private readonly MiniUdemyDBContext _Context;
        public UserProfileAdminRepository(MiniUdemyDBContext context)
        {
            _Context = context;
        }

        public Task<UserProfile> getUserProfileById(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<UserProfile> GetUserProfileById(string userId)
        {

            return await _Context.UserProfiles.FirstOrDefaultAsync(up=>up.ApplicationUserId.Equals(userId));

        }
    }
    
    
}
