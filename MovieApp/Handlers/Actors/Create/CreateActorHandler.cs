using AutoMapper;
using MediatR;
using MovieApp.Database;
using MovieApp.Database.Entities;

namespace MovieApp.Handlers.Actors.Create
{
    public class CreateActorHandler : IRequestHandler<CreateActorRequets, Guid>
    {
        private readonly MovieAppDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActorHandler(MovieAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateActorRequets request, CancellationToken cancellationToken)
        {
            var actor = _mapper.Map<Actor>(request);
            _dbContext.Add(actor);
            await _dbContext.SaveChangesAsync();
            return actor.Id;
        }
    }
}
