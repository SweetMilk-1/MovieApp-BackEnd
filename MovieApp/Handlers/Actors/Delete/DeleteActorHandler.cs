using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;

namespace MovieApp.Handlers.Actors.Delete
{
    public class DeleteActorHandler : IRequestHandler<DeleteActorRequest>
    {
        private readonly MovieAppDbContext _context;

        public DeleteActorHandler(MovieAppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(DeleteActorRequest request, CancellationToken cancellationToken)
        {
            if (!await _context.Actors.AnyAsync(x => x.Id == request.Id)) {
                throw new BadRequestException($"Актер {request.Id} не найден");
            }

            _context.Actors.Remove(new Database.Entities.Actor
            {
                Id = request.Id,
            });

            await _context.SaveChangesAsync();  
        }
    }
}
