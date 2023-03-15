using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common.Enums;
using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.UI.Extensions;
using Alperen.AdvertisamentApp.UI.Models;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.UI.Controllers
{
    public class Advertisament : Controller
    {
        private readonly IAppUserService _appuserService;
        private readonly IAdvertisamentAppUserService _advertisamentAppUserService;
        private readonly IMapper _mapper;


        public Advertisament(IAppUserService appuserService, IAdvertisamentAppUserService advertisamentAppUserService, IMapper mapper)
        {
            _appuserService = appuserService;
            _advertisamentAppUserService = advertisamentAppUserService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> Send(int advertisamentId)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var userResponse = await _appuserService.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.Genders = userResponse.Data.GenderId;
            var list = new List<MilitaryStatusListDto>();
            var itemsId = Enum.GetValues(typeof(MilitaryStatusType));
            foreach (int item in itemsId)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }
            ViewBag.MilitaryStatusList = new SelectList(list, "Id", "Definition");
            return View(new AdvertisamentAppUserModel
            {
                UserId = userId,
                AdvertisamentId = advertisamentId,

            });
        }
        [Authorize(Roles = "Member")]
        [HttpPost]
        public async Task<IActionResult> Send(AdvertisamentAppUserModel appUserModel)
        {
            AdvertisamentUserCreateDto createDto = new();
            if (appUserModel.CvFile != null)
            {
                var uzanti = Path.GetExtension(appUserModel.CvFile.FileName);
                var randomisim = Guid.NewGuid().ToString();
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "cvfiles", randomisim + uzanti);
                var stream = new FileStream(path, FileMode.Create);
                createDto.CvPath = path;

            }
            createDto.EndDate = appUserModel.EndDate;
            createDto.AdvertisamentId = appUserModel.AdvertisamentId;
            createDto.UserId = appUserModel.UserId;
            createDto.AdvertisamentUserStatusId = appUserModel.AdvertisamentUserStatusId;
            createDto.MilitaryStatusId = appUserModel.MilitaryStatusId;
            createDto.WorkExperiance = appUserModel.WorkExperiance;

            var response = await _advertisamentAppUserService.CreateAsync(createDto);
            if (response.ResponseType == Common.ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    ModelState.AddModelError(error.PropertyName, error.Message);
                }
                var userid = int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
                var userresponse = await _appuserService.GetByIdAsync<AppUserListDto>(userid);
                ViewBag.Genders = userresponse.Data.GenderId;
                var list = new List<MilitaryStatusListDto>();
                var militaryid = Enum.GetValues(typeof(MilitaryStatusType));
                foreach (int item in militaryid)
                {
                    list.Add(new MilitaryStatusListDto
                    {
                        Id = item,
                        Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                    });
                }
                ViewBag.MilitaryStatusList = new SelectList(list, "Id", "Definition");


                return View(appUserModel);
            }
            else
            {
                return RedirectToAction("HumanResorce", "Home");
            }

        }
    }
}
