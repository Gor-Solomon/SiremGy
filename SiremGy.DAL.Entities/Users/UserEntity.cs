using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SiremGy.DAL.Entities.Users
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        // Unique Index
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] Image { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
