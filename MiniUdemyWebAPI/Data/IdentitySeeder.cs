using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MiniUdemyWebAPI.Data
{
    public class IdentitySeeder
    {
        public static  void SeedRolesAsync(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "Instructor",
                    NormalizedName = "INSTRUCTOR"
                },
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"
                }
            );
        }
    }
}


