using FluentValidationWithCustomException.Models;
using FluentValidationWithCustomException.Validations.Exception;
using FluentValidationWithCustomException.Validations.InputValidationServices;
using FluentValidationWithCustomException.Validations.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FluentValidationWithCustomException
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INewAddressRequestValidationService validationService = 
                new NewAddressRequestValidationService();
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
                validationService.ValidateAndThrow(newAddressRequest);
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
