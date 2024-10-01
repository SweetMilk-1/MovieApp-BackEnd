using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.Actors.UploadImage
{
    public class ActorUploadImageRequest : IRequest
    {
        [FromRoute]
        public Guid ActorId { get; set; }
        public IFormFile File { get; set; }
    }
}
