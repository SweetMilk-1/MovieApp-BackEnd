using MediatR;
using MovieApp.Models.Common;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Genre.GetList
{
    public class GetGenresListRequest : IRequest<PagedListWrapper<DictionaryItemDto>>, IPagedRequest
    {
        public string? Search { get; set; }
        public int PerPage { get; set; } = 1000;
        public int Page { get; set;} = 1;
    }
}
