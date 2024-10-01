using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Actors.Update
{
    public class UpdateActorRequest : ActorDto, IRequest<Guid>
    {
    }
}
