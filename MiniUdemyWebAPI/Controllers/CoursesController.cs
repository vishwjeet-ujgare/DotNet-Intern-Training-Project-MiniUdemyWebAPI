using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.DTO.Course;

namespace MiniUdemyWebAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController(MiniUdemyDBContext _miniUdemyDB) : ControllerBase
    {
        //private readonly MiniUdemyDBContext _miniUdemyDB;

        //public CoursesController(MiniUdemyDBContext context)
        //{
        //    _miniUdemyDB = context;
        //}

        [HttpGet("search")]
        public async Task<IActionResult> SearchCourses(
            string? search


            )
        {
            var query = _miniUdemyDB.Courses
                  .Include(c => c.Category)
                  .Include(c => c.Language)
                  .AsQueryable();

            // Filtering with multiple conditions
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Title.Contains(search) || c.Description.Contains(search));
            }




            var results = await query.Select(c => new CoursePublicDto
            {
                CourseId = c.CourseId,
                Title = c.Title,
                Headline=c.Headline,
                Description = c.Description,
                Duration = c.Duration,
                ThumbnailUrl = c.ThumbnailUrl,
                Language = c.Language.LanguageName,
                Fees=c.Fees
                


            }).ToListAsync();

            return Ok(new
            {
                Success = true,
                Data = results
            });
        }

    }
}
