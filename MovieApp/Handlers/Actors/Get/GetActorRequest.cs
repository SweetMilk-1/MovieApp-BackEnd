using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.Actors.Get
{
    public class GetActorRequest : IRequest<ActorDto>
    {
        public Guid Id { get; set; }
    }
}
