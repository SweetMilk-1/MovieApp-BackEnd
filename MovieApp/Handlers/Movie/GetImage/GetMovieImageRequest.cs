using MediatR;

namespace MovieApp.Handlers.Movie.GetImage
{
    public class GetMovieImageRequest : IRequest<byte[]>
    {
        public Guid MovieId { get; set; }
    }
}
