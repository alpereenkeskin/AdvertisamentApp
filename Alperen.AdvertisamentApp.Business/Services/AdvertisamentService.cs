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
    public class AdvertisamentService : Service<AdvertisamentCreateDto, AdvertisamentUpdateDto, AdvertisamentListDto, Advertisament>, IAdvertisamentService
    {
        private readonly IUow _uow;
        private readonly IMapper _mapper;


        public AdvertisamentService(IValidator<AdvertisamentCreateDto> createValidator, IValidator<AdvertisamentUpdateDto> updateValidator, IMapper mapper, IUow uow) : base(createValidator, updateValidator, mapper, uow)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IResponse<List<AdvertisamentListDto>>> GetActivesAsync()
        {
            var values = await _uow.GetRepository<Advertisament>().GetAllAsync(x => x.CreatedTime, x => x.Status, Common.Enums.OrderByType.DESC);
            var dto = _mapper.Map<List<AdvertisamentListDto>>(values);
            return new Response<List<AdvertisamentListDto>>(ResponseType.Success, dto);
        }
    }

}
