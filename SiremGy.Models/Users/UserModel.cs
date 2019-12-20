using System;
using System.ComponentModel.DataAnnotations;

namespace SiremGy.Models.Users
{
    public class UserModel : ModelBase
    {
        public Guid UniqueID { get; set; }
        public virtual string UserName { get; set; }
        [EmailAddress]
        public virtual string Email { get; set; }
        public virtual DateTime Birthday { get; set; }
        [Phone]
        public virtual string MobileNumber { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Country { get; set; }
        public virtual string Address { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual DateTime CreationDate { get; set; }
    }
}
