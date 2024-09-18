using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Database.Entities;
using MovieApp.Infrastucture.Exceptions;

namespace MovieApp.Handlers.Actors.Update
{
    public class UpdateActorHandler : IRequestHandler<UpdateActorRequest>
    {
        IMapper _mapper;
        MovieAppDbContext _dbContext;

        public UpdateActorHandler(MovieAppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateActorRequest request, CancellationToken cancellationToken)
        {
            if (!await _dbContext.Actors.AnyAsync(x => x.Id == request.Id))
                throw new BadRequestException($"Актер {request.Id} не найден");

            var actor = _mapper.Map<Actor>(request);
            actor.Id = request.Id.Value;

            _dbContext.Update(actor);
            await _dbContext.SaveChangesAsync();
        }
    }
}
