using AutoMapper;
using SiremGy.BLL.Models.Photos;
using SiremGy.DAL.Entities.Photos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiremGy.Common.AutoMapper.Photos
{
    class AutoMapperPhotoProfile : Profile
    {
        public AutoMapperPhotoProfile()
        {
            CreateMap<PhotoModel, PhotoEntity>().
                ForMember(dest => dest.UserDetailId, opt => opt.Ignore()).
                ForMember(dest => dest.UserDetail, opt => opt.Ignore()); ;
            CreateMap<PhotoEntity, PhotoModel>();
            //.ForSourceMember(src => src.User, opt => opt.)
        }
    }
}
