using Alperen.AdvertisamentApp.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alperen.AdvertisamentApp.Business.ValidationRules
{
    public class AdvertisamentAppUserUpdateDtoValidator : AbstractValidator<AdvertisamentUserUpdateDto>
    {
        public AdvertisamentAppUserUpdateDtoValidator()
        {
            RuleFor(x => x.AdvertisamentId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty().WithMessage("Tescil tarihi boş bırakılamaz.");
            RuleFor(x => x.WorkExperiance).NotEmpty().WithMessage("İş deneyimi boş bırakılamaz");
            RuleFor(x => x.CvPath).NotEmpty().WithMessage("CV dosyası boş bırakılamaz");
        }
    }
}
