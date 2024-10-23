using MediatR;
using MovieApp.Handlers.User.Authentication;

namespace MovieApp.Models.Dto
{
    public class AuthenticationRequest : IRequest<AuthTokensDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
