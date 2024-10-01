using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.User.Get
{
    public class GetUserRequest : IRequest<UserDto>
    {
        public Guid UserId { get; set; }
    }
}
