using System;

namespace SiremGy.DAL.Entities.Users
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
