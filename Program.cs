using FluentValidationWithCustomException.Models;
using FluentValidationWithCustomException.Validations.Exception;
using FluentValidationWithCustomException.Validations.NewAddressRequestValidation;

namespace FluentValidationWithCustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INewAddressRequestValidatorService validatorService = 
                new NewAddressRequestValidatorService();
            var newAddressRequest = new NewAddressRequest
            {
                Address = "123 Main St",
                City = "Anytown in the world",
                Country = "USA",
                PostalCode = "1234",
                IsForeignAddress = false
            };
            try
            {
                validatorService.ValidateAndThrow(newAddressRequest);
                // Proceed with further processing
            }
            catch (InputValidationException ex)
            {
                // Handle validation exception
                foreach (var error in ex.Errors)
                {
                    Console.WriteLine(error);
                }
            }
            Console.WriteLine("End");
            Console.WriteLine("Press Key");
            Console.ReadKey();
        }
    }
}
