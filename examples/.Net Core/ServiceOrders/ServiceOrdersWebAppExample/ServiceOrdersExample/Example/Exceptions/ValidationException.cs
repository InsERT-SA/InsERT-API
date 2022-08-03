using ServiceOrdersExample.ErrorDetails;

namespace ServiceOrdersExample.Exceptions
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
