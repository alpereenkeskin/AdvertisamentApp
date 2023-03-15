using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.UI.Extensions;
using Alperen.AdvertisamentApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGenderService _genderService;
        IValidator<AppUserLoginDto> _userLoginValidator;
        private readonly IValidator<UserCreateModel> _userCreateModelValidator;
        private readonly IAppUserService _appUserService;
        private readonly IMapper _mapper;



        public AccountController(IGenderService genderService, IValidator<UserCreateModel> userCreateModelValidator, IAppUserService appUserService, IMapper mapper, IValidator<AppUserLoginDto> userLoginValidator)
        {
            _genderService = genderService;
            _userCreateModelValidator = userCreateModelValidator;
            _appUserService = appUserService;
            _mapper = mapper;
            _userLoginValidator = userLoginValidator;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignUp()
        {
            var response = await _genderService.GetListAsync();
            var model = new UserCreateModel()
            {
                Genders = new SelectList(response.Data, "Id", "Definition")
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateModel usermodel)
        {
            var result = await _userCreateModelValidator.ValidateAsync(usermodel);
            if (result.IsValid)
            {
                var dto = _mapper.Map<AppUserCreateDto>(usermodel);
                var createResponse = await _appUserService.CreateUserWithRoleAsync(dto, (int)RoleType.Member);
                return this.ResponseViewRedirect(createResponse, "SignIn");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var respone = await _genderService.GetListAsync();
            usermodel.Genders = new SelectList(respone.Data, "Id", "Definition", usermodel.GenderId);
            return View(usermodel);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginDto loginDto)
        {
            var result = await _appUserService.CheckUser(loginDto);

            if (result.ResponseType == Common.ResponseType.Success)
            {
                var userRoles = await _appUserService.GetRolesByUserIdAsync(result.Data.Id);

                var claims = new List<Claim>();

                if (userRoles.ResponseType == Common.ResponseType.Success)
                {
                    foreach (var role in userRoles.Data)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, role.Definition));
                    }
                }
                claims.Add(new Claim(ClaimTypes.NameIdentifier, result.Data.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = loginDto.RememberMe
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }
            return View(loginDto);
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index","Home");
        }
    }
}
