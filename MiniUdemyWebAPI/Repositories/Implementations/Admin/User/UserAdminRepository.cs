using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.DTO.Course;
using MiniUdemyWebAPI.Helpers;
using MiniUdemyWebAPI.Models.UserModels;
using MiniUdemyWebAPI.Repositories.Interfaces.Admin.Users;



namespace MiniUdemyWebAPI.Repositories.Implementations.Admin.User
{
    public class UserAdminRepository : IUserAdminRepository
    {
        private readonly MiniUdemyDBContext _Context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserAdminRepository(MiniUdemyDBContext context, UserManager<ApplicationUser> userManager)
        {
            _Context = context;
            _userManager = userManager;
        }

        public async Task<PagedResult<ApplicationUser>> GetAllUsersAsync(UserQueryParameters parameters)
        {
            PagedResult<ApplicationUser> response;

            try
            {
                var query = _Context.Users
                    .Include(up => up.UserProfile)
                    .Include(ur => ur.UserRoles)
                    .AsQueryable();

                // Get the total count of users
                var totalItems = await query.CountAsync();

                // Apply pagination and retriving data here
                var users = await query
                    .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                    .Take(parameters.PageSize)
                    .ToListAsync();

                response = new PagedResult<ApplicationUser>(users, totalItems, parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log it)
                response = new PagedResult<ApplicationUser>(new List<ApplicationUser>(), 0, parameters.PageNumber, parameters.PageSize);
            }

            return response;
        }


    
        public async Task<List<IdentityRole>> GetUserRolesByIdAsync(string userId)
        {
            var userRoles = await _Context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .ToListAsync();

            var roles = await _Context.Roles
            .Where(r => userRoles.Contains(r.Id))
            .ToListAsync();

            return  roles;
        }


        public async Task<bool> CreateUserAsync(ApplicationUser user)
        {
            _Context.Users.Add(user);
            return await _Context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteUserAsync(string userId)
        {
            var user = await _Context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            _Context.Users.Remove(user);

            return await _Context.SaveChangesAsync() > 0;
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _Context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string userId)
        {

            return await _Context.Users.FirstOrDefaultAsync(u => u.Id == userId, CancellationToken.None);
        }

        //public Task<PagedResult<ApplicationUser>> GetUsersByRoleAsync(string roleName, UserQueryParameters parameters)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            _Context.Users.Update(user);
            return await _Context.SaveChangesAsync() > 0;

        }

       
    }
}
