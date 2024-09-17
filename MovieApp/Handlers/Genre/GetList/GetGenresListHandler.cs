using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Models;

namespace MovieApp.Handlers.Genre.GetList
{
    public class GetGenresListHandler : IRequestHandler<GetGenresListRequest, PagedListWrapper<DictionaryItemDto>>
    { 
        private readonly MovieAppDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetGenresListHandler(MovieAppDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<PagedListWrapper<DictionaryItemDto>> Handle(GetGenresListRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Genres
                 .AsNoTracking()
                 .AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{request.Search}%"));

            var totalCount = query.Count();
            
            query = query
                .Skip(request.PerPage * (request.Page - 1))
                .Take(request.PerPage);
            var items = await _mapper.ProjectTo<DictionaryItemDto>(query).ToListAsync();

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
