using Microsoft.AspNetCore.Mvc;
using MiniUdemyWebAPI.DTO.Course;

namespace MiniUdemyWebAPI.Repositories.Interfaces.Course
{
    public interface ICourseRepository
    {
        //Task<List<Course>> GetAllCoursesAsync();
        //Task<CourseCardDto> GetCourseByIdAsync(int id);
        Task<List<CourseCardDto>> SearchCoursesAsync(
            string? search,
            string? level,

            decimal? minPrice,
            decimal? maxPrice,

            string? price,  // paid , free
           [FromQuery] List<string>? langs,

            string sortBy = "most-relevant",
            int page = 1,
            int pageSize = 10
        //string sortOrder = "asc" // asc, desc
        );

        //Task<bool> AddCourseAsync(Course course);
        //Task<bool> UpdateCourseAsync(Course course);
        //Task<bool> DeleteCourseAsync(int id);
    }
}
