using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string firstName { get; set; }
    public string lastName { get; set; }

    public virtual string? Created_by { get; set; }
    public virtual bool Is_Delete { get; set; } = false;

    public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; }

}
