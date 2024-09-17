using System.ComponentModel.DataAnnotations;

namespace User.Management.API.Models.Login
{
    public class LoginUser
    {
        [Required(ErrorMessage = "UserName is Required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string? Password { get; set; }
    }
}
