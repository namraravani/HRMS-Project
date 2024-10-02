using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRMS.POC.Project.Web.API.Data
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

            // Seed roles
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "HR", NormalizedName = "HR" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "SuperAdmin", NormalizedName = "SUPERADMIN" }
            );

            // Seed a SuperAdmin user
            var superAdminId = Guid.NewGuid().ToString();
            var superAdminUser = new ApplicationUser
            {
                Id = superAdminId,
                UserName = "namraravani",
                NormalizedUserName = "NAMRARAVANI",
                Email = "namraravani8@gmail.com",
                NormalizedEmail = "NAMRARAVANI8@GMAIL.COM",
                PhoneNumber = "9427662325",
                firstName = "Namra",
                lastName = "Ravani",
                Created_by = superAdminId,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            builder.Entity<ApplicationUser>().HasData(superAdminUser);

            // Seed the organization
            var organizationId = Guid.NewGuid().ToString();
            var organization = new Organization
            {
                Id = organizationId,
                orgName = "Evision",
                address = "Gandhinagar"
            };

            builder.Entity<Organization>().HasData(organization);

            // Seed the OrganizationUser relationship
            builder.Entity<OrganizationUser>().HasData(
                new OrganizationUser
                {
                    OrganizationId = organizationId,
                    UserId = superAdminId
                }
            );

            // Configure the OrganizationUser entity
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
    }
}
