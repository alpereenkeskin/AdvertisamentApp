using Alperen.AdvertisamentApp.Business.Extensions;
using Alperen.AdvertisamentApp.Business.Interfaces;
using Alperen.AdvertisamentApp.Common;
using Alperen.AdvertisamentApp.DataAccess.UnitOfWork;
using Alperen.AdvertisamentApp.Dtos.Interfaces;
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
    public class Service<CreateDto, UpdateDto, ListDto, T> : IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : IDto, new()
        where UpdateDto : IUpdateDto, new()
        where ListDto : IDto, new()
        where T : BaseEntity, new()
    {

        private readonly IValidator<CreateDto> _createvalidator;
        private readonly IValidator<UpdateDto> _updatevalidator;
        private readonly IMapper _mapper;
        private readonly IUow _uow;

        public Service(IValidator<CreateDto> createvalidator, IValidator<UpdateDto> updatevalidator, IMapper mapper, IUow uow)
        {
            _createvalidator = createvalidator;
            _updatevalidator = updatevalidator;
            _mapper = mapper;
            _uow = uow;
        }

        public async Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto)
        {
            var result = _createvalidator.Validate(createDto);
            if (result.IsValid)
            {
                var addedValue = _mapper.Map<T>(createDto);
                await _uow.GetRepository<T>().CreateAsync(addedValue);
                await _uow.SaveChangesAsync();
                return new Response<CreateDto>(ResponseType.Success, createDto);
            }
            return new Response<CreateDto>(ResponseType.ValidationError, result.ConvertToCustomValidation(), createDto);

        }
        public async Task<IResponse> RemoveAsync(int id)
        {
            var value = await _uow.GetRepository<T>().FindAsync(id);
            if (value == null)
            {
                return new Response(ResponseType.NotFound, "Veri Bulunamadı");
            }
            _uow.GetRepository<T>().Remove(value);
            await _uow.SaveChangesAsync();
            return new Response(ResponseType.Success);
        }

        public async Task<IResponse<List<ListDto>>> GetListAsync()
        {
            var list = await _uow.GetRepository<T>().GetAllAsync();
            var mappedlist = _mapper.Map<List<ListDto>>(list);
            return new Response<List<ListDto>>(ResponseType.Success, mappedlist);
        }

        public async Task<IResponse<IDto>> GetByIdAsync<IDto>(int id)
        {
            var value = await _uow.GetRepository<T>().FindAsync(id);
            //var mappedvalue = _mapper.Map<IDto>(value);
            if (value == null)
            {
                return new Response<IDto>(ResponseType.NotFound, $"{id} sine ait veri Bulunamadı");
            }
            var mappedvalue = _mapper.Map<IDto>(value);
            return new Response<IDto>(ResponseType.Success, mappedvalue);
        }

        public async Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto)
        {
            var result = _updatevalidator.Validate(updateDto);
            if (result.IsValid)
            {
                var unchangeddata = await _uow.GetRepository<T>().FindAsync(updateDto.Id);
                if (unchangeddata == null)
                {
                    return new Response<UpdateDto>(ResponseType.NotFound, updateDto);
                }
                var entity = _mapper.Map<T>(updateDto);
                _uow.GetRepository<T>().Update(entity, unchangeddata);
                await _uow.SaveChangesAsync();
                return new Response<UpdateDto>(ResponseType.Success, result.ConvertToCustomValidation(), updateDto);
            }
            return new Response<UpdateDto>(ResponseType.NotFound, updateDto);
        }
    }
}