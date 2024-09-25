using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRMS.POC.Project.Web.API.Models
{
    public class HrmsDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public HrmsDbContext(DbContextOptions<HrmsDbContext> options) : base(options) { }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<OrganizationUser> OrganizationUsers { get; set; }

       

        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            SeedData(builder);

            builder.Entity<OrganizationUser>()
                .HasKey(ou => new { ou.OrganizationId, ou.UserId });

            builder.Entity<OrganizationUser>()
                .HasOne(ou => ou.Organization)
                .WithMany(o => o.OrganizationUsers)
                .HasForeignKey(ou => ou.OrganizationId);

            builder.Entity<OrganizationUser>()
                .HasOne(ou => ou.User)
                .WithMany(u => u.OrganizationUsers)
                .HasForeignKey(ou => ou.UserId);
        }

        private static void SeedData(ModelBuilder builder)
        {
            
            var roleIdAdmin = Guid.NewGuid().ToString();
            var roleIdHR = Guid.NewGuid().ToString();
            var roleIdEmployee = Guid.NewGuid().ToString();
            var roleIdSuperAdmin = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = roleIdAdmin, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = roleIdHR, Name = "HR", NormalizedName = "HR" },
                new IdentityRole { Id = roleIdEmployee, Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = roleIdSuperAdmin, Name = "SuperAdmin", NormalizedName = "SUPERADMIN"}
            );

            
            var organizationId = Guid.NewGuid().ToString();
            builder.Entity<Organization>().HasData(
                new Organization { Id = organizationId, orgName = "Evision", address = "Gandhinagar" }
            );

            
            var userId = Guid.NewGuid().ToString();
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = userId,firstName = "Namra",lastName = "Ravani" ,UserName = "namraravani", Email = "namraravani8@gmail.com", PasswordHash = GetHashString("Namra@123"),Created_by = userId,PhoneNumber = "9427662325" }
            );

            
            builder.Entity<OrganizationUser>().HasData(
                new OrganizationUser { OrganizationId = organizationId, UserId = userId }
            );

            
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = userId, RoleId = roleIdAdmin }
            );
        }
    }
}
