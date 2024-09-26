using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Extensions;
using MovieApp.Models.Common;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.GetList
{
    public class GetMoviesListHandler : IRequestHandler<GetMoviesListRequest, PagedListWrapper<MovieItemDto>>
    {
        private readonly MovieAppDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesListHandler(IMapper mapper, MovieAppDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<PagedListWrapper<MovieItemDto>> Handle(GetMoviesListRequest request, CancellationToken cancellationToken)
        {
            var query = _context.Movies.AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, $"%{request.Search}%"));
            }

            if (request.Genres != null && request.Genres.Any())
            {
                query = query.Where(x => x.Genres.Any(y => request.Genres.Contains(y.Id)));
            }

            if (request.Actors != null && request.Actors.Any())
            {
                query = query.Where(x => x.Genres.Any(y => request.Actors.Contains(y.Id)));
            }

            if (request.BeginReleaseYear.HasValue)
            {
                query = query.Where(x => x.ReleaseDate >= new DateTime(request.BeginReleaseYear.Value, 1, 1));
            }

            if (request.EndReleaseYear.HasValue)
            {
                query = query.Where(x => x.ReleaseDate < new DateTime(request.EndReleaseYear.Value + 1, 1, 1));
            }

            var totalCount = query.Count();
            var items = await query
                .Paging(request.Page, request.PerPage)
                .ProjectTo<MovieItemDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            var pageCount = (totalCount + request.PerPage - 1) / request.PerPage;

            return new PagedListWrapper<MovieItemDto>
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
