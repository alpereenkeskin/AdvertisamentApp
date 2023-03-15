using Alperen.AdvertisamentApp.Dtos;
using FluentValidation;

namespace Alperen.AdvertisamentApp.Business.ValidationRules
{
    public class GenderCreateValidator:AbstractValidator<GenderCreateDto>
    {
        public GenderCreateValidator()
        {
            RuleFor(x => x.Definition).NotEmpty();
        }
    }
}
