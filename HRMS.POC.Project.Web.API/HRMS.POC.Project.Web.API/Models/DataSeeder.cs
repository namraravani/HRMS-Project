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
        // Ensure roles are created
        var roles = new[] { "Admin", "HR", "Employee", "SuperAdmin" };
        foreach (var role in roles)
        {
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var Id = Guid.NewGuid().ToString();
        var user = new ApplicationUser
        {
            Id = Id,
            firstName = "Namra",
            lastName = "Ravani",
            UserName = "namraravani",
            Email = "namraravani8@gmail.com",
            PhoneNumber = "9427662325",
            Created_by = Id 
        };

        var result = await _userManager.CreateAsync(user, "Namra@123");
        if (result.Succeeded)
        {
            // Assign role to the user
            await _userManager.AddToRoleAsync(user, "SuperAdmin");

            // Seed organization
            var organization = new Organization
            {
                Id = Guid.NewGuid().ToString(),
                orgName = "Evision",
                address = "Gandhinagar"
            };

            await _dbContext.Organizations.AddAsync(organization);
            await _dbContext.SaveChangesAsync();

            // Seed OrganizationUser
            var organizationUser = new OrganizationUser
            {
                OrganizationId = organization.Id,
                UserId = user.Id
            };

            await _dbContext.OrganizationUsers.AddAsync(organizationUser);
            await _dbContext.SaveChangesAsync();
        }
    }
}
