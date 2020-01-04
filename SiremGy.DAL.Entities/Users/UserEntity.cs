using SiremGy.DAL.Entities.Photos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiremGy.DAL.Entities.Users
{
    public class UserEntity : IEntity
    {
        public int Id { get; set; }
        [Required]
        public Guid UniqueID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Index("UQ_UserEmail", IsClustered = false, IsUnique = true)]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public UserDetailEntity UserDetail { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActive { get; set; }
    }
}
