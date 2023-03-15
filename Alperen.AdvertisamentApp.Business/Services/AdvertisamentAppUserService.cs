using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common;
using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.DataAccess.UnitOfWork;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Services
{
    public class AdvertisamentAppUserService : Service<AdvertisamentUserCreateDto, AdvertisamentUserUpdateDto, AdvertisamentUserListDto, AdvertisamentUser>, IAdvertisamentAppUserService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;

        public AdvertisamentAppUserService(IValidator<AdvertisamentUserCreateDto> createvalidator, IValidator<AdvertisamentUserUpdateDto> updatevalidator, IMapper mapper, IUow uow) : base(createvalidator, updatevalidator, mapper, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public List<AdvertisamentUserListDto> ListByStatus(AdvertisamentAppUserStatusType appUserStatusType)
        {
            var query = _uow.GetRepository<AdvertisamentUser>().GetQuery();
            var list = query.Include(x => x.AppUser).Include(x => x.Advertisament).Include(x => x.AdvertisamentUserStatus).Include(x => x.MilitaryStatus).Where(x => x.AdvertisamentUserStatusId == (int)appUserStatusType).ToList();
            return _mapper.Map<List<AdvertisamentUserListDto>>(list);
        }
        public async Task SetStatus(int advertisamentUserDtoId, AdvertisamentAppUserStatusType appUserStatusType)
        {
            var query = _uow.GetRepository<AdvertisamentUser>().GetQuery();
            var user = await query.FirstOrDefaultAsync(x => x.Id == advertisamentUserDtoId);
            user.AdvertisamentUserStatusId = (int)appUserStatusType;
            await _uow.SaveChangesAsync();
        }
    }
}
