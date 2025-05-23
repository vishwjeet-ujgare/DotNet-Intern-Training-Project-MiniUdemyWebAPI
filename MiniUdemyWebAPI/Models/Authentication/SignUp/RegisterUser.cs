﻿using System.ComponentModel.DataAnnotations;

namespace MiniUdemyWebAPI.Models.Authentication.SignUp
{
    public class RegisterUser
    {

        [Required(ErrorMessage ="User name is required")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Passwor is required")]
        public string? Password { get; set; }

    }
}
