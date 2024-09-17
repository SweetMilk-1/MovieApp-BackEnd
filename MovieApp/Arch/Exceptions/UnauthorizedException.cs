using System.Net;
namespace MovieApp.Arch.Exceptions
{
    /// <summary>
    /// Исключение Unauthorized
    /// </summary>
    public class UnauthorizedException : HttpErrorWithStatusCodeException
    {
        public UnauthorizedException(string message, object? additionalData = null) : base(HttpStatusCode.Unauthorized, message, additionalData)
        {
        }
    }
}
