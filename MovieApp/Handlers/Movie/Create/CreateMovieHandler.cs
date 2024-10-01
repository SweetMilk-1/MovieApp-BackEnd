using AutoMapper;
using MediatR;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Movie.Create
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieRequest, Guid>
    {
        private readonly IMapper _mapper;
        private readonly MovieAppDbContext _context;
        private readonly IUserInfoService _userInfoService;

        public CreateMovieHandler(MovieAppDbContext context, IMapper mapper, IUserInfoService userInfoService)
        {

            _context = context;
            _mapper = mapper;
            _userInfoService = userInfoService;
        }

        public async Task<Guid> Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Database.Entities.Movie>(request);

            movie.CreatedByUserId = _userInfoService.UserJwtInfoDto.UserId;

            var genreIds = request.Genres.Select(x => x.Id).ToHashSet();
            var actorIds = request.Actors.Select(x => x.Id).ToHashSet();
            
            var genres = _context.Genres.Where(x => genreIds.Contains(x.Id)).ToList();
            var actors = _context.Actors.Where(x => actorIds.Contains(x.Id)).ToList();

            movie.Actors = actors;
            movie.Genres = genres;

            movie.CreatedByUserId = request.CreatedByUserId;

            _context.Add(movie);

            await _context.SaveChangesAsync();
            return movie.Id;
        }
    }
}
