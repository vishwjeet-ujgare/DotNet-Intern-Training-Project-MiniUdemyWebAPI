using Microsoft.EntityFrameworkCore;
using MiniUdemyWebAPI.Models.UserModels;
using MiniUdemyWebAPI.Models.UserProfileModels;

namespace MiniUdemyWebAPI.Data
{
    public class MiniUdemyDBContext : DbContext
    {
        public MiniUdemyDBContext(DbContextOptions<MiniUdemyDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Add any custom configurations here
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<User>()
                .HasMany(u => u.UserRoles)
                .WithOne(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);


            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId=1,RoleName="Admin"},
                new Role { RoleId=2,RoleName="Instructor"},
                new Role { RoleId=3,RoleName="Student"}
                );
        }


        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserProfileAddr> UserProfileAddrs { get; set; }
        public DbSet<UserProfileImg> UserProfileImgs { get; set; }
    }
}
