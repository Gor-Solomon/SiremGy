using AutoMapper;
using SiremGy.BLL.Models.Users;
using SiremGy.DAL.Entities.Users;
using SiremGy.Common.Extensions;

namespace SiremGy.Common.AutoMapper.Users
{
    class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UserDetailModel, UserDetailEntity>().
                ForMember(dest => dest.UserId, opt => opt.Ignore());
            CreateMap<UserDetailEntity, UserDetailModel>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Birthday.CalculateAge()));

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
