using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.UI.Models;
using AutoMapper;

namespace Alperen.AdvertisamentApp.UI.Mappings
{

    public class UserCreateModelProfile:Profile
    {
        public UserCreateModelProfile()
        {
            CreateMap<UserCreateModel, AppUserCreateDto>().ReverseMap();
            CreateMap<UserCreateModel, AppUserUpdateDto>().ReverseMap();
            CreateMap<UserCreateModel, AppUserListDto>().ReverseMap();
        }
    }
}
