using AutoMapper;
using MediatR;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.User;

namespace MovieApp.Handlers.Movie.Delete
{

    public class DeleteMovieHandler : IRequestHandler<DeleteMovieRequest>
    {
        private readonly MovieAppDbContext _context;
        private readonly IUserInfoService _userInfoService;
        public DeleteMovieHandler(MovieAppDbContext context, IUserInfoService userInfoService)
        {
            _context = context;
            _userInfoService = userInfoService;
        }
        public async Task Handle(DeleteMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FindAsync(request.Id) ?? throw new BadRequestException($"Фильм {request.Id} не найден");
            
            if (movie.CreatedByUserId != _userInfoService.UserJwtInfoDto?.UserId || !_userInfoService.UserJwtInfoDto.IsAdmin)
            {
                throw new ForbiddenException($"Недостаточно прав");
            }

            _context.Remove(movie);

            await _context.SaveChangesAsync();
        }      
    }
}
