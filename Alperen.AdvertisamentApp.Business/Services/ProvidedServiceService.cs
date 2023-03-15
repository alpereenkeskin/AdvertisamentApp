using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Business.ValidationRules;
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
    public class ProvidedServiceService : Service<ProvidedServiceCreateDto, 
        ProvidedServiceUpdateDto, ProvidedServiceListDto, ProvidedService>,
        IProvidedServiceService
    {
        public ProvidedServiceService(IUow uow, IValidator<ProvidedServiceCreateDto> createvalidator, IValidator<ProvidedServiceUpdateDto> updatevalidator, IMapper mapper) : base(createvalidator, updatevalidator, mapper, uow)
        {

        }
    }
}
