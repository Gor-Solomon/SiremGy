using AutoMapper;
using SiremGy.DAL.Entities.Users;
using SiremGy.Models.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.Common.AutoMapper.Users
{
    class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UserModel, UserEntity>();
            CreateMap<UserEntity, UserModel>();
        }
    }
}
