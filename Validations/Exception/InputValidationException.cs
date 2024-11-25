namespace FluentValidationWithCustomException.Validations.Exception
{
    public class InputValidationException : System.Exception
    {
        public List<string> Errors { get; }
        public InputValidationException(List<string> errors)
            : base("Fluentvalidation failed")
        {
            Errors = errors;
        }
    }
}
