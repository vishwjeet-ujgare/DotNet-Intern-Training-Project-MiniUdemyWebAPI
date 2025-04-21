using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.DTO.Course;
using MiniUdemyWebAPI.DTO.EnrollmentDtos;
using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Repositories.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace MiniUdemyWebAPI.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CoursesController(ICourseRepository _courseRepository) : ControllerBase
    {


        [HttpGet("search")]
        public async Task<IActionResult> SearchCourses(
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

            )
        {

            var courses = await _courseRepository.SearchCoursesAsync(search, level, minPrice, maxPrice, price, langs, sortBy, page, pageSize);
         
            if (courses == null || !courses.Any())
            {
                return NotFound(new { Success = false, Message = "No courses found" });
            }


            ////Paging

            var totalRecords = courses.Count();

            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return Ok(new
            {
                Success = true,
                TotalResults = totalRecords,
                CurrentPage = page,
                PageSize = pageSize,
                TotalPages = totalPages,
                Data = courses
            });
        }







        //[HttpGet("{courseId:int}")]
        //public async Task<IActionResult> GetCourseById(int courseId)
        //{

        //    var course = await _miniUdemyDB.Courses
        //        .Include(c => c.Category)
        //        .Include(c => c.User)
        //            .ThenInclude(u => u.UserProfile)
        //        .Include(c => c.Language)
        //        .Include(c => c.Enrollments)
        //            .ThenInclude(e => e.Rating)
        //        .FirstOrDefaultAsync(c => c.CourseId == courseId);

        //    if (course == null)
        //    {
        //        return NotFound(new { Success = false, Message = "Course not found" });
        //    }



        //    var EnrollementDetails = await _miniUdemyDB.Enrollments
        //     .Include(e => e.User)
        //     .Where(e => e.CourseId == courseId)
        //     .Select(e => new EnrollmentPublicDto
        //     {
        //         Status = e.Status.ToString(),
        //         //TotalEnrolledCount = e.Course.Enrollments.Count(en => en.Status.Equals(EnrollmentStatus.Completed.ToString()) || en.Status.Equals(EnrollmentStatus.Enrolled.ToString())),
        //         TotalEnrolledCount = e.Course.Enrollments.Count(),
        //     })
        //     .ToListAsync();



        //    // Check if the course is published
        //    var result = new CourseDetailsDto
        //    {
        //        CourseId = course.CourseId,
        //        ThumbnailUrl = course.ThumbnailUrl,
        //        Title = course.Title,
        //        Headline = course.Headline,
        //        //created by
        //        UserId = course.User.UserId,
        //        Instructor = course.User.FirstName + " " + course.User.UserProfile.LastName,

        //        //last udpate
        //        UpdatedAt = course.UpdatedAt,
        //        //lang
        //        Language = course.Language.LanguageName,

        //        //total learners
        //        //TotalLearners = course.Enrollments.Count(e => e.Status == EnrollmentStatus.Completed || e.Status == EnrollmentStatus.Enrolled),


        //        //total reviews count and avg rating
        //        TotalRatingCount = course.Enrollments.Count(e => e.Rating != null),
        //        AvgRating = course.Enrollments.Count(e => e.Rating != null) > 0 ?
        //                    course.Enrollments.Average(e => e.Rating.Stars) : 0,

        //        //related topics
        //        Duration = course.Duration,
        //        //Instructors Information
        //        //Featured review 4 reviews
        //        //More coruses by instructor




        //        Description = course.Description,
        //        Level = course.Level.ToString(),
        //        Fees = course.Fees,



        //    };


        //    return Ok(new { Success = true, Data = result });
        //}


        //public async Task<IActionResult> UploadImage(IFormFile imageFile)
        //{
        //    if (imageFile == null || imageFile.Length == 0)
        //    {
        //        return BadRequest("No image file provided.");
        //    }

        //    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
        //    if (!Directory.Exists(uploadsFolder))
        //    {
        //        Directory.CreateDirectory(uploadsFolder);
        //    }

        //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(imageFile.FileName);
        //    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        //    using (var fileStream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await imageFile.CopyToAsync(fileStream);
        //    }

        //    var image = new Image
        //    {
        //        FileName = uniqueFileName,
        //        FilePath = "/images/" + uniqueFileName
        //    };

        //    _context.Images.Add(image);
        //    await _context.SaveChangesAsync();

        //    return Ok(new { image.Id, image.FilePath });
        //}

    }

}
