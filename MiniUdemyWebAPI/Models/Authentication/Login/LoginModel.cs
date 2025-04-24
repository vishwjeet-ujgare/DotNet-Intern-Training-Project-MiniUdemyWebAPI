using System.ComponentModel.DataAnnotations;

//namespace MiniUdemyWebAPI.Models.Authentication.Login
namespace MiniUdemyWebAPI.Models.Authentication.Login
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Username is required")]
        //public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }


    }
}
