    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography;
namespace HRMS.POC.Project.Web.API.Models
{
        public class HrmsDbContext : IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public HrmsDbContext(DbContextOptions<HrmsDbContext> options) : base(options) { 


        }

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

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.Created_by).HasMaxLength(256); 
                entity.Property(e => e.Is_Delete).HasDefaultValue(false);
            });

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
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Name = "HR", ConcurrencyStamp = "2", NormalizedName = "HR" },
                new IdentityRole() { Name = "Employee", ConcurrencyStamp = "3", NormalizedName = "Employee" }

            );
            var organizationId = Guid.NewGuid();
            var userId = Guid.NewGuid().ToString();
            var 

            builder.Entity<Organization>().HasData(
                new Organization() { orgName = "Evision", address = "Gandhinagar"}
            );

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { Id = userId ,UserName = "Namra",Email = "namraravani8@gmail.com", PasswordHash = GetHashString("Namra@123"), }
            );

            builder.Entity<OrganizationUser>().HasData(
                new OrganizationUser() { OrganizationId = organizationId,UserId = userId }
            );

        }
    }
    }
