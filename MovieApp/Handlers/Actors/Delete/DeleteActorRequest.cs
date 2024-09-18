using MediatR;

namespace MovieApp.Handlers.Actors.Delete
{
    public class DeleteActorRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
