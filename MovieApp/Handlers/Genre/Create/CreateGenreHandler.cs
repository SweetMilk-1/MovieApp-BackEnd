using MediatR;
using MovieApp.Database;

namespace MovieApp.Handlers.Genre.Create
{
    public class CreateGenrehandler : IRequestHandler<CreateGenreRequest>
    {
        private readonly MovieAppDbContext _context;
        public CreateGenrehandler(MovieAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(CreateGenreRequest request, CancellationToken cancellationToken)
        {
            var genre = new Database.Entities.Genre
            {
                Name = request.Name,
            };
            
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }
    }
}
