using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.User.Authentication
{
    public class AuthenticationRequest : IRequest<AuthTokensDto>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
