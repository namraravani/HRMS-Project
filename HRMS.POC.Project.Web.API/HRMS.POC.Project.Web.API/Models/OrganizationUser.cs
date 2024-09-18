using HRMS.POC.Project.Web.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrganizationUser
{
    
    [Required]
    public string OrganizationId { get; set; }

    [Required]
    public string UserId { get; set; }

    [ForeignKey("OrganizationId")]
    public virtual Organization Organization { get; set; }

    [ForeignKey("UserId")]
    public virtual ApplicationUser User { get; set; }
}