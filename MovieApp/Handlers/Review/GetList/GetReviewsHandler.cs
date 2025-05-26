using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Extensions;
using MovieApp.Models.Common;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Review.GetList
{
    public class GetReviewsHandler : IRequestHandler<GetReviewsRequest, PagedListWrapper<ReviewDto>>
    {
        private readonly MovieAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetReviewsHandler(MovieAppDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PagedListWrapper<ReviewDto>> Handle(GetReviewsRequest request, CancellationToken cancellationToken)
        {

            var query = _dbContext.Reviews
                 .AsNoTracking()
                 .AsQueryable()
                 .Where(x => x.MovieId ==request.MovieId);

            if (!string.IsNullOrEmpty(request.Sort))
            {
                switch (request.Sort)
                {
                    case ReviewSortWay.ByCreateDateAsc:
                        query = query.OrderBy(x => x.CreatedAt);
                        break;
                    case ReviewSortWay.ByCreateDateDesc:
                        query = query.OrderByDescending(x => x.CreatedAt);
                        break;
                    case ReviewSortWay.ByGradeAsc:
                        query = query.OrderBy(x => x.Grade);
                        break;
                    case ReviewSortWay.ByGradeDesc:
                        query = query.OrderByDescending(x => x.Grade);
                        break;
                    default:
                        break;
                }
            }

            var totalCount = query.Count();

            query = query.Paging(request.Page, request.PerPage);

            var items = await _mapper.ProjectTo<ReviewDto>(query).ToListAsync();

            var pageCount = (totalCount + request.PerPage - 1) / request.PerPage;

            return new PagedListWrapper<ReviewDto>
            {
                Page = request.Page,
                TotalCount = totalCount,
                PageCount = pageCount,
                PerPage = request.PerPage,
                Items = items
            };
        }
    }
}

