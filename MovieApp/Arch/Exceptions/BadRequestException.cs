using System.Net;

namespace MovieApp.Arch.Exceptions
{
    /// <summary>
    /// Исключение для BadRequest
    /// </summary>
    public class BadRequestException : HttpErrorWithStatusCodeException
    {
        public BadRequestException(string message, object? additionalData = null) : base(HttpStatusCode.BadRequest, message, additionalData)
        {
        }
    }
}
