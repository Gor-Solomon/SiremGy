using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiremGy.Models.Users
{
    public class LoginModel : ModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [System.ComponentModel.PasswordPropertyText(true)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Passwrod must have at least 8 and at most 100 characters.")]
        public string Password { get; set; }
    }
}
