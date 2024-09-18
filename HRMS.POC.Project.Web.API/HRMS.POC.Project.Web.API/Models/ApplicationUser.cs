using HRMS.POC.Project.Web.API.Models;
using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public virtual string Created_by { get; set; }
    public virtual bool Is_Delete { get; set; } = true;

    public virtual ICollection<OrganizationUser> OrganizationUsers { get; set; }

}
