using Alperen.AdvertisamentApp.Common;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Interfaces
{
    public interface IAppUserService : IService<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>
    {
        Task<IResponse<AppUserCreateDto>> CreateUserWithRoleAsync(AppUserCreateDto createDto,int roleId);
        Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto loginDto);
        Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userid);
    }
}
