using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.User.UploadImage
{
    public class UserUploadImageRequest : IRequest
    {
        [FromRoute]
        public Guid UserId { get; set; }
        public IFormFile File { get; set; }
    }
}
