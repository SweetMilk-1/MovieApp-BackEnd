using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;

namespace MovieApp.Handlers.Genre.Update
{
    public class UpdateGenreHandler : IRequestHandler<UpdateGenreRequest>
    {

        private readonly MovieAppDbContext _context;

        public UpdateGenreHandler(MovieAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FindAsync(request.Id) ?? throw new BadRequestException($"Жанр {request.Id} не найден");

            genre.Name = request.Name;

            await _context.SaveChangesAsync();
        }
    }
}
