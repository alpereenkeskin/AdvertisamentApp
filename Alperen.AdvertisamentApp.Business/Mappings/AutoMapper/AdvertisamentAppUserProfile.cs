using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Mappings.AutoMapper
{
    public class AdvertisamentAppUserProfile:Profile
    {
        public AdvertisamentAppUserProfile()
        {
            CreateMap<AdvertisamentUser, AdvertisamentUserCreateDto>().ReverseMap();
            CreateMap<AdvertisamentUser, AdvertisamentUserUpdateDto>().ReverseMap();
            CreateMap<AdvertisamentUser, AdvertisamentUserListDto>().ReverseMap();
        }
    }
}
