using System.Net;

namespace MovieApp.Arch.Exceptions
{
    /// <summary>
    /// Исключение Forbidden
    /// </summary>
    public class ForbiddenException : HttpErrorWithStatusCodeException
    {
        public ForbiddenException(string message, object? additionalData = null) : base(HttpStatusCode.Forbidden, message, additionalData)
        {
        }
    }
}
