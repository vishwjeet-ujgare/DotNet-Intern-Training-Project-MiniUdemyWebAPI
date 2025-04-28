using Microsoft.AspNetCore.Mvc;
using MiniUdemyWebAPI.Helpers;
using MiniUdemyWebAPI.Services.Admin.Users;

namespace MiniUdemyWebAPI.Controllers.Admin.Users
{
    [Route("api/admin")]
    [ApiController]
    public class UserAdminController : ControllerBase
    {

        private readonly IUserAdminService _userAdminService;

        public UserAdminController(IUserAdminService userService)
        {
            _userAdminService = userService;
        }


        [HttpGet("users")]
        public async Task<IActionResult> GetAllUsers([FromQuery] UserQueryParameters queryParameters)
        {
            // This is a placeholder for the actual implementation

            var users = await _userAdminService.GetAllUsersAsync(queryParameters);
            return Ok(users);

        }
    }
}
