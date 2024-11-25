using FluentValidation;
using FluentValidation.Results;
using FluentValidationWithCustomException.Models;
using FluentValidationWithCustomException.Validations.Exception;
using FluentValidationWithCustomException.Validations.Interfaces;
using FluentValidationWithCustomException.Validations.Validators;

namespace FluentValidationWithCustomException.Validations.InputValidationServices
{
    public class NewAddressRequestValidationService : INewAddressRequestValidationService
    {
        private readonly IValidator<NewAddressRequest> _validator;

        public NewAddressRequestValidationService()
        {
            _validator = new NewAddressRequestValidator();
        }

        public void ValidateAndThrow(NewAddressRequest request)
        {
            ValidationResult result = _validator.Validate(request);
            if (!result.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ErrorMessage);
                    //errors.Add($"Validation failed for property {error.PropertyName}: {error.ErrorMessage}");
                }
                throw new InputValidationException(errors);
            }
        }
    }
}
