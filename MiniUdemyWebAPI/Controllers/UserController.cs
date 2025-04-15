using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniUdemyWebAPI.Data;

namespace MiniUdemyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MiniUdemyDBContext _miniUdemyDBContext;

        public UserController(MiniUdemyDBContext appDBContext)
        {
            _miniUdemyDBContext = appDBContext;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            //var users = _miniUdemyDBContext.Users.ToList();
            var users = (from userTbl in _miniUdemyDBContext.Users
                         select userTbl).ToList();

            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }
            return Ok(users);
        }

    }
}
