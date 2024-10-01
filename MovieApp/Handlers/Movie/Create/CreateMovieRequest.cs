using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Create
{
    public class CreateMovieRequest : MovieDto, IRequest<Guid>
    {
        public CreateMovieRequest() {
            Id = null;
        }
    }
}
