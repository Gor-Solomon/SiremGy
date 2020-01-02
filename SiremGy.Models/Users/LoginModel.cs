using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiremGy.BLL.Models.Users
{
    public class LoginModel : ModelBase
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [System.ComponentModel.PasswordPropertyText(true)]
        public string Password { get; set; }
    }
}
