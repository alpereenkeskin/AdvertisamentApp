using Alperen.AdvertisamentApp.Dtos;
using FluentValidation;

namespace Alperen.AdvertisamentApp.Business.ValidationRules
{
    public class ProvidedServiceDtoCreateValidator:AbstractValidator<ProvidedServiceCreateDto>
    {
        public ProvidedServiceDtoCreateValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x=>x.ImagePath).NotEmpty(); 
        }

    }
}
