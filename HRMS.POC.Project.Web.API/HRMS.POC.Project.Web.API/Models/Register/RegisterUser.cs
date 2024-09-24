using System.ComponentModel.DataAnnotations;

namespace HRMS.POC.Project.Web.API.Models.Register
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string? firstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string? lastName { get; set; }

        [Required(ErrorMessage = "User Name is Required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is Required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}
