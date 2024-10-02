using HRMS.POC.Project.Web.API.Data;
using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class DataSeeder
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly HrmsDbContext _dbContext;

    public DataSeeder(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, HrmsDbContext dbContext)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        
        var roles = new[] { "Admin", "HR", "Employee", "SuperAdmin" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(role));
                if (!roleResult.Succeeded)
                {
                    Console.WriteLine($"Failed to create role: {role}. Errors: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    return; 
                }
            }
        }

        
        var superAdminEmail = "namraravani8@gmail.com";
        var superAdminUser = await _userManager.FindByEmailAsync(superAdminEmail);
        if (superAdminUser == null)
        {
            var Id = Guid.NewGuid().ToString();
            var user = new ApplicationUser
            {
                Id = Id,
                firstName = "Namra",
                lastName = "Ravani",
                UserName = "namraravani",
                Email = superAdminEmail,
                PhoneNumber = "9427662325",
                Created_by = Id
            };

            var result = await _userManager.CreateAsync(user, "Namra@123");
            if (result.Succeeded)
            {
                
                var roleResult = await _userManager.AddToRoleAsync(user, "SuperAdmin");
                if (!roleResult.Succeeded)
                {
                    Console.WriteLine($"Failed to assign role to SuperAdmin. Errors: {string.Join(", ", roleResult.Errors.Select(e => e.Description))}");
                    return;
                }

               
                var organization = new Organization
                {
                    Id = Guid.NewGuid().ToString(),
                    orgName = "Evision",
                    address = "Gandhinagar"
                };

                await _dbContext.Organizations.AddAsync(organization);
                await _dbContext.SaveChangesAsync();

                
                var organizationUser = new OrganizationUser
                {
                    OrganizationId = organization.Id,
                    UserId = user.Id
                };

                await _dbContext.OrganizationUsers.AddAsync(organizationUser);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"Failed to create SuperAdmin user. Errors: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
        else
        {
            Console.WriteLine("SuperAdmin user already exists.");
        }
    }

}
