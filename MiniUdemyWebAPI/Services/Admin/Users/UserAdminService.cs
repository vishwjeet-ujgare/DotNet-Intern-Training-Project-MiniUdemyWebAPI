using MiniUdemyWebAPI.DTO.Users;
using MiniUdemyWebAPI.Helpers;
using MiniUdemyWebAPI.Repositories.Implementations.Admin.User;
using MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users;




namespace MiniUdemyWebAPI.Services.Admin.Users
{
    public class UserAdminService : IUserAdminService
    {
        private readonly IUserAdminRepository _userAdminRepo;
        private readonly IUserProfileAdminRepository _userProfileRepository;

        public UserAdminService(IUserAdminRepository userAdminRepo, IUserProfileAdminRepository userProfileRepository)
        {
            this._userAdminRepo = userAdminRepo;
            this._userProfileRepository = userProfileRepository;
        }


        public async Task<List<UserBasicInfoDTO>> GetAllUsersAsync(UserQueryParameters userQueryParameters)

        {
            //get all users 
            var users = await _userAdminRepo.GetAllUsersAsync(userQueryParameters);

            //combine with UserProfile information
            var userBasicInfoDTOs = users.Items.Select(user =>
            {

                var UserProfile = _userProfileRepository.GetUserProfileById(user.Id).Result;
                var userRoles=_userAdminRepo.GetUserRolesByIdAsync(user.Id).Result;

                return new UserBasicInfoDTO
                {
                    Id = user.Id,
                    FirstName = UserProfile?.FirstName,
                    Roles = userRoles.Select(role => role.Name).ToList(),
                    Email = user.Email,
                    IsActive = user.IsActive,
                    CreatedAt = user.CreatedAt
                };

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
