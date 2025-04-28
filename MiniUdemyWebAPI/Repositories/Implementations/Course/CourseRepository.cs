using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Data;
using MiniUdemyWebAPI.DTO.Course;
using MiniUdemyWebAPI.Repositories.Interfaces.Course;
using static MiniUdemyWebAPI.DTO.Course.CourseCardDto;

namespace MiniUdemyWebAPI.Repositories.Implementations.Course
{
    public class CourseRepository(MiniUdemyDBContext _miniUdemyDB) : ICourseRepository
    {

       
        
        public async Task<List<CourseCardDto>> SearchCoursesAsync(string? search, string? level, decimal? minPrice, decimal? maxPrice, string? price, [FromQuery] List<string>? langs, string sortBy = "most-relevant", int page = 1, int pageSize = 10)
        {


            var query = _miniUdemyDB.Courses
                 .Include(c => c.Category)
                 .Include(c => c.ApplicationUser)
                 .Include(c => c.Language)
                 .Include(c => c.Enrollments)
                   .ThenInclude(e => e.Rating)
                 .AsQueryable();

            // Filtering with multiple conditions
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c =>

                (c.Title != null && c.Title.Contains(search)) ||
                (c.Headline != null && c.Headline.Contains(search)) ||
                (c.Description != null && c.Description.Contains(search)));
            }

            if (!string.IsNullOrEmpty(level) && Enum.TryParse<CourseLevels>(level, true, out var parsedLevel))
                query = query.Where(c => c.Level.Equals(parsedLevel));

            if (minPrice.HasValue)
                query = query.Where(c => c.Fees >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(c => c.Fees <= maxPrice.Value);

            if (!string.IsNullOrEmpty(price))
            {
                if (price.ToLower() == "free")
                    query = query.Where(c => c.Fees < decimal.Parse("0.01"));
                if (price.ToLower() == "paid")
                    query = query.Where(c => c.Fees > decimal.Parse("0.00"));
            }

            // Any() => checks if the collection has any elements
            if (langs.Any() && langs != null)
            {
                query = query.Where(c => langs.Any(lan
                    => c.Language.LanguageName.Equals(lan)));
            }

            //Sorting by 
            //most-relecant --->default
            //-- Newest
            //price -- low to high
            //price -- high to low
            //most reviewed => how many star/ratings a course has and sorty by that i.e how many users have given rating
            //-- Highest-rated => need to cal avg rating per course and sort by that

            query = (sortBy?.ToLower()) switch
            {
                ("most-relevant") => query.OrderByDescending(c =>
                        (EF.Functions.Like(c.Title, $"{search} %") ? 4 : 0) +
                    (EF.Functions.Like(c.Title, $"%{search}%") ? 3 : 0) +
                    (EF.Functions.Like(c.Headline, $"%{search}%") ? 2 : 0) +
                    (EF.Functions.Like(c.Description, $"%{search}%") ? 2 : 0)),

                ("price-high-low") => query.OrderByDescending(c => c.Fees),
                ("price-low-high") => query.OrderBy(c => c.Fees),
                ("newest") => query.OrderByDescending(c => c.CreatedAt),

                ("highest-ratings") => query.OrderByDescending(c =>
                        c.Enrollments.Any(e => e.Rating != null) ?
                            c.Enrollments.Where(e => e.Rating != null)
                            .Average(e => e.Rating.Stars) : 0),


                ("most-reviewed") => query.OrderByDescending(c =>
                        c.Enrollments.Count(e => e.Rating != null)),
                //("rating", "desc") => query.OrderByDescending(c => c.Enrollments.Average(e => e.Rating.Starts)),

                _ => query.OrderBy(c => c.Title)
            };


            // at page 1 skip 0 records
            // at page 2 skip 10 recods
            // at page 3 skip 20 records
            // and so on 
            var results = await query.Select(c => new CourseCardDto
                {
                    CourseId = c.CourseId,

                    Title = c.Title,
                    Headline = c.Headline,
                    ThumbnailUrl = c.ThumbnailUrl,
                    Duration = c.Duration,

                    Instructor = c.ApplicationUser.UserName,

                    TotalRatingCount = c.Enrollments.Count(e => e.Rating != null),
                    AvgRating = c.Enrollments.Count(e => e.Rating != null) > 0 ?
                            c.Enrollments.Average(e => e.Rating.Stars) : 0,

                    Level = c.Level.ToString(),

                    Fees = c.Fees,

                }).ToListAsync();



            //Paging

            //var totalRecords = await query.CountAsync();

            //var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            return results;

        }
    }
}
