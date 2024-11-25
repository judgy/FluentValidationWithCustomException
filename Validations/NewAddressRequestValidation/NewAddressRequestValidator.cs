using FluentValidation;

namespace FluentValidationWithCustomException.Validations.NewAddressRequestValidation;

public class NewAddressRequestValidator : AbstractValidator<Models.NewAddressRequest>
{
    public NewAddressRequestValidator()
    {
        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required")
            .Length(5, 100)
            .When(x => !x.IsForeignAddress)
            .WithMessage("Address must be between 5 and 100 characters");
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required")
            .When(x => !x.IsForeignAddress)
            .Length(2, 10)
            .When(x => !x.IsForeignAddress)
            .WithMessage("City must be between 2 and 10 characters");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required")
            .Length(2, 50)
            .When(x => !x.IsForeignAddress)
            .WithMessage("Country must be between 2 and 50 characters");
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required")
            .Length(5)
            .When(x => !x.IsForeignAddress)
            .WithMessage("Postal code must be 5 characters");
    }
}