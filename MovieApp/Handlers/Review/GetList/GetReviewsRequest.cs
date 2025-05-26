using MediatR;
using MovieApp.Models.Common;
using MovieApp.Models.Dto;
using MovieApp.Models.Interfaces;

namespace MovieApp.Handlers.Review.GetList
{
    public class GetReviewsRequest : IRequest<PagedListWrapper<ReviewDto>>, IPagedRequest
    {
        public Guid MovieId { get; set; }
        public string? Sort { get; set; } = ReviewSortWay.ByGradeDesc;
        public int PerPage { get; set; } = 1000;
        public int Page { get; set; } = 1;
    }
}
