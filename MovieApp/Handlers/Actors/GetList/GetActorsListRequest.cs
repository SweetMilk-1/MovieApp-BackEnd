using MediatR;
using MovieApp.Models;

namespace MovieApp.Handlers.Actors.GetList
{
    public class GetActorsListRequest : IRequest<PagedListWrapper<DictionaryItemDto>>
    {
        public string? Search { get; set; }
        public int PerPage { get; set; } = 1000;
        public int Page { get; set; } = 1;
    }
}
