using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SiremGy.Models.Users
{
    public class RegisterModel : ModelBase
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "User name should be between 3 and 100 characters.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 64 characters.")]
        public string Password { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Country { get; set; }
        
        [Required]
        public string Gender { get; set; }

        [Required]
        public string MobileNumber { get; set; }       
    }
}
