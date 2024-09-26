using MediatR;
using MovieApp.Models.Common;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Actors.GetList
{
    public class GetActorsListRequest : IRequest<PagedListWrapper<DictionaryItemDto>>, IPagedRequest
    {
        public string? Search { get; set; }
        public int PerPage { get; set; } = 1000;
        public int Page { get; set; } = 1;
    }
}
