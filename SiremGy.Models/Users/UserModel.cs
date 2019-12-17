using System;
using System.ComponentModel.DataAnnotations;

namespace SiremGy.Models.Users
{
    public class UserModel : ModelBase
    {
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "User Name must have at least 3 and at most 100 characters.")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [System.ComponentModel.PasswordPropertyText(true)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Passwrod must have at least 8 and at most 100 characters.")]
        public string Password { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
