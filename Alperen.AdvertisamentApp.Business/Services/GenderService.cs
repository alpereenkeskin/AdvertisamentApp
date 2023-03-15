using Alperen.AdvertisamentApp.Business.Interfaces;
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
    public class GenderService : Service<GenderCreateDto, GenderUpdateDto, GenderListDto, Gender>, IGenderService
    {
        public GenderService(IValidator<GenderCreateDto> createvalidator, IValidator<GenderUpdateDto> updatevalidator, IMapper mapper, IUow uow) : base(createvalidator, updatevalidator, mapper, uow)
        {

        }
    }
}
