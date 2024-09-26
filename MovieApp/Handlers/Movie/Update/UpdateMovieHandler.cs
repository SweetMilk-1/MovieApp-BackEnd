using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Movie.Update
{
    public class UpdateMovieHandler : IRequestHandler<UpdateMovieRequest>
    {
        private readonly MovieAppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserInfoService _userInfoService;
        public UpdateMovieHandler(MovieAppDbContext context, IMapper mapper, IUserInfoService userInfoService)
        {
            _context = context;
            _mapper = mapper;
            _userInfoService = userInfoService;
        }

        public async Task Handle(UpdateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = 
                await _context.Movies
                .Include(x => x.Actors)
                .Include(x => x.Genres)
                .FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new BadRequestException($"Фильм {request.Id} не найден");

            if (movie.CreatedByUserId != _userInfoService.UserJwtInfoDto.UserId)
            {
                throw new BadRequestException($"Недостаточно прав");
            }

            movie.Title = request.Title;
            movie.Description = request.Description;
            movie.PgInfo = request.PgInfo;
            movie.DurationInMinutes = request.DurationInMinutes;
            
            if (request.Actors != null)
            {
                var actorIds = request.Actors.Select(x => x.Id);
                movie.Actors = await _context.Actors.Where(x => actorIds.Contains(x.Id)).ToListAsync();

            }

            if (request.Genres != null)
            {
                var genreIds = request.Genres.Select(x => x.Id);
                movie.Genres = await _context.Genres.Where(x => genreIds.Contains(x.Id)).ToListAsync();
            }

            await _context.SaveChangesAsync();
        }
    }
}
