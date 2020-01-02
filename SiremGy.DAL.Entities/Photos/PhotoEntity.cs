using SiremGy.DAL.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SiremGy.DAL.Entities.Photos
{
    public class PhotoEntity : IEntity
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool Visible { get; set; }
        public DateTime DateAdded { get; set; }

        [ForeignKey("UserDetail")]
        public int UserDetailId { get; set; }
        [InverseProperty("Photos")]
        public virtual UserDetailEntity UserDetail { get; set; }
    }
}
