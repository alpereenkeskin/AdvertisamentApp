using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Interfaces
{
    public interface IAdvertisamentAppUserService : IService<AdvertisamentUserCreateDto, AdvertisamentUserUpdateDto, AdvertisamentUserListDto, Advertisament>
    {
        List<AdvertisamentUserListDto> ListByStatus(AdvertisamentAppUserStatusType appUserStatusType);
        Task SetStatus(int advertisamentUserDtoId, AdvertisamentAppUserStatusType appUserStatusType);
    }
}
