using FluentValidation;
using FluentValidation.Results;
using FluentValidationWithCustomException.Validations.Exception;

namespace FluentValidationWithCustomException.Validations.NewAddressRequestValidation
{
    public class NewAddressRequestValidatorService : INewAddressRequestValidatorService
    {
        private readonly IValidator<Models.NewAddressRequest> _validator;

        public NewAddressRequestValidatorService()
        {
            _validator = new NewAddressRequestValidator();
        }

        public void ValidateAndThrow(Models.NewAddressRequest request)
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
