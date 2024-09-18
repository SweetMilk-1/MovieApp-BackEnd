using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Actors.Create
{
    public class CreateActorRequets : ActorDto, IRequest 
    {
    }
}
