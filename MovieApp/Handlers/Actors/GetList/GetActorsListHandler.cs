using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Extensions;
using MovieApp.Models.Common;

namespace MovieApp.Handlers.Actors.GetList
{
    public class GetActorsListHandler : IRequestHandler<GetActorsListRequest, PagedListWrapper<DictionaryItemDto>>
    {
        MovieAppDbContext _dbContext;
        IMapper _mapper;

        public GetActorsListHandler(IMapper mapper, MovieAppDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<PagedListWrapper<DictionaryItemDto>> Handle(GetActorsListRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Actors
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{request.Search}%"));
            }

            var totalCount = query.Count();
            var items = await query
                .Paging(request.Page, request.PerPage)
                .ProjectTo<DictionaryItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var pageCount = (totalCount + request.PerPage - 1) / request.PerPage; 

            return new PagedListWrapper<DictionaryItemDto>
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
