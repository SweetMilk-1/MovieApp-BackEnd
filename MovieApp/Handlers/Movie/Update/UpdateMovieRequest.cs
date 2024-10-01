using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Update
{
    public class UpdateMovieRequest : MovieDto, IRequest<Guid>
    {

    }
}
