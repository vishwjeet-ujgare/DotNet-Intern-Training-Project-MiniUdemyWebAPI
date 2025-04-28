using MiniUdemyWebAPI.DTO.Users;
using MiniUdemyWebAPI.Helpers;
using MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users;

namespace MiniUdemyWebAPI.Services.Admin.Users
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IUserAdminRepository _userAdminRepo;

        public UserAdminService(IUserAdminRepository userAdminRepo)
        {
            _userAdminRepo = userAdminRepo;

        }


        public async Task<List<UserBasicInfoDTO>> GetAllUsersAsync(UserQueryParameters userQueryParameters)

        {
            var users = await _userAdminRepo.GetAllUsersAsync(userQueryParameters);

            var userBasicInfoDTOs = users.Items.Select(user => new UserBasicInfoDTO
            {
                Id = user.Id,
                //FirstName = user.UserProfile.FirstName,

                Email = user.Email,
                //IsActive = user.IsActive,
                //CreatedAt = user.CreatedAt
            }).ToList();

            return userBasicInfoDTOs;

        }

        public Task<List<UserBasicInfoDTO>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }



        //public async Task<UserBasicInfoDTO> GetUserByIdAsync(string id)
        //{
        //    var user = await _userAdminRepo.GetUserByIdAsync(id);

        //}
        // Other methods can be implemented similarly
    }

}
