using Microsoft.AspNetCore.Identity;

public class ApplicationUser : IdentityUser
{
    public string Created_by { get; set; }
    public bool Is_Delete { get; set; } = true;
}
