using MediatR;

namespace MovieApp.Handlers.User.GetImage
{
    public class GetUserImageRequest : IRequest<byte[]>
    {
        public Guid UserId { get; set; }
    }
}
