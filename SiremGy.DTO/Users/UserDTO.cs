using SiremGy.BLL.Models.Photos;
using SiremGy.BLL.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SiremGy.DTO.Users
{
    public class UserDTO
    {
        public UserDTO()
        {
        }
        public UserDTO(UserModel userModel)
        {
            Id = userModel.Id;
            UserName = userModel.UserName;
            KnownAs = userModel.UserDetail.Nickname;
            Age = userModel.UserDetail.Age;
            Gender = userModel.UserDetail.Gender;
            LastActive = userModel.LastActive;
            Created = userModel.CreationDate;
            PhotoUrl = userModel.UserDetail.Photo.Url;
            City = userModel.UserDetail.City;
            Country = userModel.UserDetail.Country;
            Interests = userModel.UserDetail.Interests;
            Introduction = userModel.UserDetail.Introduction;
            LookingFor = userModel.UserDetail.LookingFor;
            Photos = userModel.UserDetail.Photos.ToList();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string KnownAs { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Interests { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public IEnumerable<PhotoModel> Photos { get; set; }

        public static IEnumerable<UserDTO> CastFromUserModelAgregate(IEnumerable<UserModel> userModels)
        {
            List<UserDTO> users = new List<UserDTO>();

            foreach (var item in userModels)
            {
                users.Add(new UserDTO(item));
            }

            return users;
        }
    }
}
