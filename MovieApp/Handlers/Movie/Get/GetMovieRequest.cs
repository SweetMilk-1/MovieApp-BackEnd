using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Get
{
    public class GetMovieRequest : IRequest<MovieDto>
    {
        public Guid Id { get; set; }
    }
}
