using Alperen.AdvertisamentApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.ValidationRules
{
    public class ProvidedServiceDtoUpdateValidator : AbstractValidator<ProvidedServiceUpdateDto>
    {
        public ProvidedServiceDtoUpdateValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.ImagePath).NotEmpty();
        }
    }
}
