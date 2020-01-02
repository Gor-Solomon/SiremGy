using System.Collections.Generic;
using SiremGy.BLL.Models.Photos;
using System;

namespace SiremGy.BLL.Models.Users
{
    public class UserDetailModel : ModelBase
    {
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }
        public UserModel User { get; set; }
        public PhotoModel Photo { get; set; }
        public IEnumerable<PhotoModel> Photos { get; set; }
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
    }
}