using Alperen.AdvertisamentApp.Dtos;
using Alperen.AdvertisamentApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.Interfaces
{
    public interface IProvidedServiceService : IService
        <ProvidedServiceCreateDto, ProvidedServiceUpdateDto,
        ProvidedServiceListDto, ProvidedService>
    {

    }
}
