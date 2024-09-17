using MediatR;

namespace MovieApp.Handlers.User.Authentication
{
    public class AuthenticationRequest : IRequest<AuthenticationResponse>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
