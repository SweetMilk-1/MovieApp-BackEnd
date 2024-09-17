using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;

namespace MovieApp.Handlers.Genre.Delete
{
    public class DeleteGenreHandler : IRequestHandler<DeleteGenreRequest>
    {
        private readonly MovieAppDbContext _context;

        public DeleteGenreHandler(MovieAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FindAsync(request.Id) ?? throw new BadRequestException($"Жанр {request.Id} не найден");

            _context.Remove(genre);

            _context.SaveChanges();
        }
    }
}
