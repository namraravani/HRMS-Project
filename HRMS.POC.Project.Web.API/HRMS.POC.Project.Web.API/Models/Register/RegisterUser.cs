using System.ComponentModel.DataAnnotations;

namespace HRMS.POC.Project.Web.API.Models.Register
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "User Name is Required")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}
