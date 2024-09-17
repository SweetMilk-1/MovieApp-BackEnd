using System.Net;

namespace MovieApp.Infrastucture.Exceptions
{
    /// <summary>
    /// Исключение NotFound
    /// </summary>
    public class NotFoundException : HttpErrorWithStatusCodeException
    {
        public NotFoundException(string message, object? additionalData = null) : base(HttpStatusCode.NotFound, message, additionalData)
        {
        }
    }
}
