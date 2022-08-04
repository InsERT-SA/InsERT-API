using System.Net;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceOrdersExample.ErrorDetails;
using ServiceOrdersExample.Exceptions;
using ValidationProblemDetails = ServiceOrdersExample.ErrorDetails.ValidationProblemDetails;

namespace ServiceOrdersExample.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        private const string DefaultErrorTitle = "Wyst�pi� nieoczekiwany b��d";
        private const string DefaultErrorMessage = "Spr�buj ponownie p�niej lub skontaktuj si� z administratorem.";

        public string Title { get; set; }
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            string title = DefaultErrorTitle;
            string message = DefaultErrorMessage;
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionFeature != null)
            {
                var exceptionThatOccurred = exceptionFeature.Error;
                if (exceptionThatOccurred is ServiceOrderNotFoundException)
                {
                    title = "Nie odnaleziono zg�oszenia";
                    message = "Nie uda�o si� znale�� ��danego zg�oszenia.";
                    statusCode = (int)HttpStatusCode.NotFound;
                }
                else if (exceptionThatOccurred is ServiceOrderApiException)
                {
                    message = $"Wykonanie ��danej operacji nie powiod�o si�. {DefaultErrorMessage}";
                }
                else if (exceptionThatOccurred is UnauthorizedException)
                {
                    title = "Dost�p do API wymaga uwierzytelnienia";
                    message = "Podaj poprawny subscription key";
                }
                else if (exceptionThatOccurred is ForbiddenException)
                {
                    title = "Odmowa dost�pu";
                }
            }

            Title = title;
            Message = message;
            HttpContext.Response.StatusCode = statusCode;

            return Page();
        }

        public IActionResult OnPost()
        {
            string title = DefaultErrorTitle;
            string message = DefaultErrorMessage;
            int statusCode = (int)HttpStatusCode.InternalServerError;

            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (exceptionFeature != null)
            {
                var exceptionThatOccurred = exceptionFeature.Error;
                if (exceptionThatOccurred is ServiceOrderApiException)
                {
                    message = $"Wykonanie ��danej operacji nie powiod�o si�. {DefaultErrorMessage}";
                }
                else if (exceptionThatOccurred is ValidationException validationException)
                {
                    title = validationException.ValidationProblemDetails.Title;
                    message = PrepareValidationErrorMessage(validationException.ValidationProblemDetails);
                }
                else if (exceptionThatOccurred is UnauthorizedException)
                {
                    title = "Dost�p do API wymaga uwierzytelnienia";
                    message = "Podaj poprawny subscription key";
                }
            }

            Title = title;
            Message = message;
            HttpContext.Response.StatusCode = statusCode;

            return Page();
        }

        private string PrepareValidationErrorMessage(ValidationProblemDetails validationProblemDetails)
        {
            var sb = new StringBuilder();
            sb.AppendLine(validationProblemDetails.Detail);
            sb.AppendLine("B��dy walidacji:");

            IEnumerable<ValidationProblem>? validationErrors = validationProblemDetails.Extensions.Where(x => x.Key == "validationProblems").Select(x => x.Value).FirstOrDefault();

            if (validationErrors == null)
            {
                return string.Empty;
            }

            foreach (var error in validationErrors)
            {
                sb.Append(" Nazwa pola: ");
                sb.AppendLine(error.FieldName);
                sb.Append(" Komunikat: ");
                sb.AppendLine(error.ErrorMessage);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
