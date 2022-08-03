using ServiceOrdersExample.Example.ErrorDetails;

namespace ServiceOrdersExample.Example.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationProblemDetails ValidationProblemDetails { get; set; }

        public ValidationException(ValidationProblemDetails validationProblemDetails)
        {
            ValidationProblemDetails = validationProblemDetails;
        }
    }
}
