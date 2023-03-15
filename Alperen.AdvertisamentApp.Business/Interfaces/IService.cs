using Alperen.AdvertisamentApp.Common;
using Alperen.AdvertisamentApp.Dtos.Interfaces;
using Alperen.AdvertisamentApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Interfaces
{
    public interface IService<CreateDto, UpdateDto, ListDto, T>
        where CreateDto : IDto, new()
        where UpdateDto : IUpdateDto, new()
        where ListDto : IDto,new()
        where T : BaseEntity
    {
        Task<IResponse<CreateDto>> CreateAsync(CreateDto createDto);
        Task<IResponse<UpdateDto>> UpdateAsync(UpdateDto updateDto);
        Task<IResponse> RemoveAsync(int id);
        Task<IResponse<IDto>> GetByIdAsync<IDto>(int id);
        Task<IResponse<List<ListDto>>> GetListAsync();
    }
}

