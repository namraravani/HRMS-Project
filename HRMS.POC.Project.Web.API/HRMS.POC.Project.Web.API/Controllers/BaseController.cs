using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public abstract class BaseController : ControllerBase
{
    protected string UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
    protected string UserName => User.FindFirstValue(ClaimTypes.Name);
    protected string UserRole => User.FindFirstValue(ClaimTypes.Role);
    protected string OrganizationId => User.FindFirstValue("OrganizationId");

    protected void ValidateUser()
    {
        if (string.IsNullOrEmpty(UserId))
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }
    }
}

