using System.ComponentModel.DataAnnotations;

namespace HRMS.POC.Project.Web.API.Models
{
    public class Organization
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Organization Name is Required")]
        
        public string OrgName { get; set; }


        [Required(ErrorMessage = "Organization Address is Required")]
        public string? Address { get; set; }

    }
}
