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
    public class AdvertisamentProfile : Profile
    {
        public AdvertisamentProfile()
        {
            CreateMap<Advertisament, AdvertisamentListDto>().ReverseMap();
            CreateMap<Advertisament, AdvertisamentCreateDto>().ReverseMap();
            CreateMap<Advertisament, AdvertisamentUpdateDto>().ReverseMap();

        }
    }
}
