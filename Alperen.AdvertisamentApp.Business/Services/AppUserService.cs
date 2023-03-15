using Alperen.AdvertisamentApp.Business.Extensions;
using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common;
using Alperen.AdvertisamentApp.DataAccess.UnitOfWork;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Services
{
    public class AppUserService : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<AppUserCreateDto> _validator;
        private readonly IUow _uow;
        private readonly IValidator<AppUserLoginDto> _validatorLogin;

        public AppUserService(IValidator<AppUserCreateDto> createvalidator, IValidator<AppUserUpdateDto> updatevalidator, IMapper mapper, IUow uow, IValidator<AppUserLoginDto> validatorLogin) : base(createvalidator, updatevalidator, mapper, uow)
        {
            _validator = createvalidator;
            _mapper = mapper;
            _uow = uow;
            _validatorLogin = validatorLogin;
        }

        public async Task<IResponse<AppUserCreateDto>> CreateUserWithRoleAsync(AppUserCreateDto createDto, int roleId)
        {
            var result = _validator.Validate(createDto);
            if (result.IsValid)
            {
                var appUserEntitiy = _mapper.Map<AppUser>(createDto);
                await _uow.GetRepository<AppUser>().CreateAsync(appUserEntitiy);
                await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
                {
                    RoleId = roleId,
                    AppUser = appUserEntitiy
                });
                await _uow.SaveChangesAsync();
                return new Response<AppUserCreateDto>(ResponseType.Success, createDto);

                //
            }
            return new Response<AppUserCreateDto>(ResponseType.ValidationError, result.ConvertToCustomValidation(), createDto);
        }
        public async Task<IResponse<AppUserListDto>> CheckUser(AppUserLoginDto loginDto)
        {
            var result = _validatorLogin.Validate(loginDto);
            if (result.IsValid)
            {
                var user = await _uow.GetRepository<AppUser>().FindByFilterAsync(x => x.UserName == loginDto.UserName && x.Password == loginDto.Password);
                var listdto = _mapper.Map<AppUserListDto>(user);
                if (user != null)
                {
                    return new Response<AppUserListDto>(ResponseType.Success, listdto);
                }
                return new Response<AppUserListDto>(ResponseType.NotFound, "Kullanıcı adı veya şifre hatalı");
            }
            return new Response<AppUserListDto>(ResponseType.ValidationError, "Kullanıcı adı veya parola boş olamaz.");

        }


        public async Task<IResponse<List<AppRoleListDto>>> GetRolesByUserIdAsync(int userid)
        {
            var userRoles = await _uow.GetRepository<AppRole>().GetAllAsync(x => x.AppUserRoles.Any(x => x.UserId == userid));
            if (userRoles == null)
            {
                return new Response<List<AppRoleListDto>>(ResponseType.NotFound, "ilgili rol bulunamadı");
            }
            var dto = _mapper.Map<List<AppRoleListDto>>(userRoles);

            return new Response<List<AppRoleListDto>>(ResponseType.Success, dto);

        }
    }
}
