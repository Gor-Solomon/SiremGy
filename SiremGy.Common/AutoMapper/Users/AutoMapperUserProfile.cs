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
            CreateMap<UserModel, UserEntity>().
                ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).
                ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
            CreateMap<UserEntity, UserModel>();

            CreateMap<RegisterModel, UserEntity>().
                ForMember(dest => dest.PasswordHash, opt => opt.Ignore()).
                ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());
        }
    }
}
