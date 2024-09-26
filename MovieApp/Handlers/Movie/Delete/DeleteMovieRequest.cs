using MediatR;

namespace MovieApp.Handlers.Movie.Delete
{
    public class DeleteMovieRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
