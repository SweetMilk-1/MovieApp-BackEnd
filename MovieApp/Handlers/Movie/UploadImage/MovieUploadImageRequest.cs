using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MovieApp.Handlers.Movie.UploadImage
{
    public class MovieUploadImageRequest : IRequest
    {
        [FromRoute]
        public Guid MovieId { get; set; }
        public IFormFile File { get; set; }
    }
}
