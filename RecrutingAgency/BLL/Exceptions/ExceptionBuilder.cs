using FluentValidation;
using System.Net;

namespace BLL.Exceptions
{
    internal static class ExceptionBuilder
    {
        internal static ValidationException Create(string message, HttpStatusCode code = HttpStatusCode.NotFound)
        {
            var exception = new ValidationException(message);
            exception.Data.Add("StatusCodeFromValidation", code);
            return exception;
        }
    }
}
