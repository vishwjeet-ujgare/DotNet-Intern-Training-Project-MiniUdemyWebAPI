using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiniUdemyWebAPI.Models.CourseModels;
using MiniUdemyWebAPI.Models.EnrollmentModels;
using MiniUdemyWebAPI.Models.RatingModels;
using MiniUdemyWebAPI.Models.UserModels;
using MiniUdemyWebAPI.Models.UserProfileModels;

namespace MiniUdemyWebAPI.Data
{
    public class MiniUdemyDBContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {   

        public MiniUdemyDBContext(DbContextOptions<MiniUdemyDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any custom configurations here
            base.OnModelCreating(modelBuilder);

            IdentitySeeder.SeedRolesAsync(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);


            // User and Courses relationship
            modelBuilder.Entity<User>()
             .HasMany(u => u.Courses)
             .WithOne(c => c.User)
             .HasForeignKey(c => c.UserId)
             .OnDelete(DeleteBehavior.NoAction);




            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Instructor" },
                new Role { RoleId = 3, RoleName = "Student" }
                );

            modelBuilder.Entity<Language>().HasData(

                new Language { LanguageId = 1, LanguageName = "English" },
                new Language { LanguageId = 2, LanguageName = "Hindi" },
                new Language { LanguageId = 3, LanguageName = "Portuguese" }

                );

            modelBuilder.Entity<CourseCategory>().HasData(
                //first 10 parent category only
                new CourseCategory { CourseCategoryId = 1, CategoryName = "Programming", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 2, CategoryName = "Data Science", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 3, CategoryName = "Web Development", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 4, CategoryName = "Mobile Development", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 5, CategoryName = "Game Development", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 6, CategoryName = "Cloud Computing", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 7, CategoryName = "Cyber Security", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 8, CategoryName = "Artificial Intelligence", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 9, CategoryName = "Machine Learning", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 10, CategoryName = "Blockchain", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 11, CategoryName = "Data Analysis", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 12, CategoryName = "Digital Marketing", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 13, CategoryName = "Graphic Design", ParentCategoryId = null },
                new CourseCategory { CourseCategoryId = 14, CategoryName = "UI/UX Design", ParentCategoryId = null },

                //Now lets add some subcategories
                new CourseCategory { CourseCategoryId = 15, CategoryName = "Web Design", ParentCategoryId = 3 },
                new CourseCategory { CourseCategoryId = 16, CategoryName = "Web Development", ParentCategoryId = 3 },
                new CourseCategory { CourseCategoryId = 17, CategoryName = "Mobile App Development", ParentCategoryId = 4 },
                new CourseCategory { CourseCategoryId = 18, CategoryName = "Game Design", ParentCategoryId = 5 },
                new CourseCategory { CourseCategoryId = 19, CategoryName = "Game Development", ParentCategoryId = 5 },
                new CourseCategory { CourseCategoryId = 20, CategoryName = "Cloud Security", ParentCategoryId = 7 },
                new CourseCategory { CourseCategoryId = 21, CategoryName = "Cloud Development", ParentCategoryId = 6 },
                new CourseCategory { CourseCategoryId = 22, CategoryName = "Data Visualization", ParentCategoryId = 11 },
                new CourseCategory { CourseCategoryId = 23, CategoryName = "Data Engineering", ParentCategoryId = 2 },

                //add some programming realted subcategories like java , c , js etc
                new CourseCategory { CourseCategoryId = 24, CategoryName = "Java", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 25, CategoryName = "C#", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 26, CategoryName = "C++", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 27, CategoryName = "JavaScript", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 28, CategoryName = "Python", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 29, CategoryName = "PHP", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 30, CategoryName = "Ruby", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 31, CategoryName = "Swift", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 32, CategoryName = "Kotlin", ParentCategoryId = 1 },

                //add some dot net related
                new CourseCategory { CourseCategoryId = 33, CategoryName = ".NET", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 34, CategoryName = "ASP.NET", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 35, CategoryName = "Django", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 36, CategoryName = "Flask", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 37, CategoryName = "Node.js", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 38, CategoryName = "React.js", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 39, CategoryName = "Angular", ParentCategoryId = 1 },
                new CourseCategory { CourseCategoryId = 40, CategoryName = "Vue.js", ParentCategoryId = 1 }









                );

            modelBuilder.Entity<Course>()
                .Property(c => c.Fees)
                .HasColumnType("decimal(18,2)");


            modelBuilder.Entity<Enrollments>()
                .Property(e => e.PurchasePrice)
                .HasColumnType("decimal(18,2)");

        }


        //UserTables
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

        //User profile
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileAddr> UserProfileAddrs { get; set; }
        public DbSet<UserProfileImg> UserProfileImgs { get; set; }

        //Course tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCategory> CourseCategories { get; set; }
        public DbSet<Language> Languages { get; set; }

        //rating table
        public DbSet<Rating> Ratings { get; set; }

        //Enrollment tables
        public DbSet<Enrollments> Enrollments { get; set; }


    }
}
