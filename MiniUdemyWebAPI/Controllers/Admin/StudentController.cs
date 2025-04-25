using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiniUdemyWebAPI.Controllers.Admin
{
    [Authorize(Roles ="Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {


        [HttpGet("all")]
        public IEnumerable<string> GetAllStudents()
        {
            return new List<string> { "Vishwjeet", "Jeet", "Captain" };
        }

    }
}
