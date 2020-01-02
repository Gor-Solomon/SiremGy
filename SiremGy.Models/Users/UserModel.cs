using SiremGy.BLL.Models.Photos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiremGy.BLL.Models.Users
{
    public class UserModel : ModelBase
    {
        public Guid UniqueID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public UserDetailModel UserDetail { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
    }
}
