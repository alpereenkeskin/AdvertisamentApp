using Alperen.AdvertisamentApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.ValidationRules
{
    public class AdvertisamentCreateDtoValidator:AbstractValidator<AdvertisamentCreateDto>
    {
        public AdvertisamentCreateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
