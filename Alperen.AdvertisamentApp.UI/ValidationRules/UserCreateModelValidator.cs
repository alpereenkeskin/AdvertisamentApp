using Alperen.AdvertisamentApp.UI.Models;
using FluentValidation;

namespace Alperen.AdvertisamentApp.UI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        public UserCreateModelValidator()
        {
            RuleFor(x => x.FirtsName).NotEmpty().WithMessage("İsim Alanı Boş Bırakılamaz.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyisim Alanı Boş Bırakılamaz.");
            RuleFor(x => x.Password).Equal(x=>x.Password).WithMessage("Parolalar eşleşmiyor"); 
        }
    }
}
