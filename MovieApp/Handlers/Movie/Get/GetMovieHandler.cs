using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Movie.Get
{
    public class GetMovieHandler : IRequestHandler<GetMovieRequest, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly MovieAppDbContext _context;

        public GetMovieHandler(MovieAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MovieDto> Handle(GetMovieRequest request, CancellationToken cancellationToken)
        {
            return await _context.Movies
                .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken) 
                ?? throw new NotFoundException($"Фильм {request.Id} не найден");
        }
    }
}
