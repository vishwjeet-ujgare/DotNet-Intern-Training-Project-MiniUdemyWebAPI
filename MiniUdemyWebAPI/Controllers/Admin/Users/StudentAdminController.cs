using Microsoft.AspNetCore.Mvc;

namespace MiniUdemyWebAPI.Controllers.Admin.Users
{
    //[Authorize(Roles ="Admin")]
    [Route("api/admin")]
    [ApiController]
    public class StudentAdminController : ControllerBase
    {

        [HttpGet("students")]
        public IEnumerable<string> GetAllStudents()
        {
            return new List<string> { "Vishwjeet", "Jeet", "Captain" };
        }

    }
}
