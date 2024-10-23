using MediatR;
using MovieApp.Handlers.User.Authentication;

namespace MovieApp.Handlers.User.RefreshTokens
{
    public class RefreshTokensRequest : IRequest<AuthTokensDto>
    {
        public string RefreshToken { get; set; }
    }
}
