namespace FluentValidationWithCustomException.Validations.NewAddressRequestValidation;

public interface INewAddressRequestValidatorService
{
    void ValidateAndThrow(Models.NewAddressRequest request);
}