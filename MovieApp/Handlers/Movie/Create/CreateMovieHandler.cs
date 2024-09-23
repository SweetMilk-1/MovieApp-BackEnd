using AutoMapper;
using MediatR;
using MovieApp.Database;
using MovieApp.Database.Entities;

namespace MovieApp.Handlers.Movie.Create
{
    public class CreateMovieHandler : IRequestHandler<CreateMovieRequest>
    {
        private readonly IMapper _mapper;
        private readonly MovieAppDbContext _context;

        public CreateMovieHandler(MovieAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Handle(CreateMovieRequest request, CancellationToken cancellationToken)
        {
            var movie = _mapper.Map<Database.Entities.Movie>(request);
            _context.Add(movie);

            await _context.SaveChangesAsync();
        }
    }
}
