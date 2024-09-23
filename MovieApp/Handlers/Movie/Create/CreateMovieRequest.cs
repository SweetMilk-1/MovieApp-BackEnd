using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Create
{
    public class CreateMovieRequest : MovieDto, IRequest
    {
        public CreateMovieRequest() {
            Id = null;
        }
    }
}
