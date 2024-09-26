using MediatR;
using MovieApp.Models.Common;
using MovieApp.Models.Dto;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Movie.GetList
{
    public class GetMoviesListRequest: IRequest<PagedListWrapper<MovieItemDto>>, IPagedRequest
    {
        public string? Search { get; set; }
        public  IEnumerable<Guid>? Genres { get; set; }
        public IEnumerable<Guid>? Actors { get; set; }
        public int? BeginReleaseYear { get; set; }
        public int? EndReleaseYear { get; set; }

        public int PerPage { get; set; } = 1000;
        public int Page { get; set; } = 1;
    }
}
