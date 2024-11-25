using FluentValidationWithCustomException.Models;

namespace FluentValidationWithCustomException.Validations.Interfaces;

public interface INewAddressRequestValidationService
{
    void ValidateAndThrow(NewAddressRequest request);
}