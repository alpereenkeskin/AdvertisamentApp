using Alperen.AdvertisamentApp.Common;
using System.Collections.Generic;

namespace Alperen.AdvertisamentApp.Business.Extensions
{
    public static class ValidationExtension
    {
        public static List<CustomValidationErrors> ConvertToCustomValidation(this FluentValidation.Results.ValidationResult result)
        {
            List<CustomValidationErrors> customValidationErrors = new();
            foreach (var error in result.Errors)
            {
                customValidationErrors.Add(new CustomValidationErrors
                {
                    PropertyName = error.PropertyName,
                    Message = error.ErrorMessage
                });

            }
            return customValidationErrors;
        }

    }
}
