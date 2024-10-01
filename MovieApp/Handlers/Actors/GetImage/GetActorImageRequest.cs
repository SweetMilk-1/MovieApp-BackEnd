using MediatR;

namespace MovieApp.Handlers.Actors.GetImage
{
    public class GetActorImageRequest : IRequest<byte[]>
    {
        public Guid ActorId { get; set; }
    }
}
