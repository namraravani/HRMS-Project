    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    namespace HRMS.POC.Project.Web.API.Models
    {
        public class HrmsDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public HrmsDbContext(DbContextOptions<HrmsDbContext> options) : base(options) { 


        }

        public DbSet<Organization> Organizations { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedRoles(builder);



            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Created_by).HasMaxLength(256); 
                entity.Property(e => e.Is_Delete).HasDefaultValue(false);
            }); 
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "HR", ConcurrencyStamp = "2", NormalizedName = "HR" },
                new IdentityRole() { Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "Employee" }

            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() {UserName = "Namra", Email = "namraravani8@gmail.com", PasswordHash = "Namra@123" }
                );
        }
    }
    }
