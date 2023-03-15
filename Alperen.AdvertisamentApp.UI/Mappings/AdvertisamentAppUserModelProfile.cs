using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.UI.Models;
using AutoMapper;

namespace Alperen.AdvertisamentApp.UI.Mappings
{
    public class AdvertisamentAppUserModelProfile : Profile
    {
        public AdvertisamentAppUserModelProfile()
        {
            CreateMap<AdvertisamentUserCreateDto, AdvertisamentAppUserModel>().ReverseMap();
            CreateMap<AdvertisamentUserUpdateDto, AdvertisamentAppUserModel>().ReverseMap();
            CreateMap<AdvertisamentUserListDto, AdvertisamentAppUserModel>().ReverseMap();
        }
    }
}
