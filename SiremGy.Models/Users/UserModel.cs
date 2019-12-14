using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.Models.Users
{
    public class UserModel : ModelBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
