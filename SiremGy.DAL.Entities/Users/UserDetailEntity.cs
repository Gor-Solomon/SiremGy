using SiremGy.DAL.Entities.Photos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiremGy.DAL.Entities.Users
{
    public class UserDetailEntity : IEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Nickname { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Intrests { get; set; }

        [InverseProperty("UserDetail")]
        public virtual UserEntity User { get; set; }

        public PhotoEntity Photo { get; set; }
        public ICollection<PhotoEntity> Photos { get; set; }
        public DateTime Birthday { get; set; }
    }
}
