using System.Net;

namespace MovieApp.Infrastucture.Exceptions
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
