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
    public class AdvertisamentAppUserStatusProfile : Profile
    {
        public AdvertisamentAppUserStatusProfile()
        {
            CreateMap<AdvertisamentUserStatus, AdvertisamentUserStatusListDto>();
        }
    }
}
