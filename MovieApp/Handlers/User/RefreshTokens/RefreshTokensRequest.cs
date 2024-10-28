using MediatR;
using MovieApp.Models.Dto;

namespace MovieApp.Handlers.User.RefreshTokens
{
    public class RefreshTokensRequest : IRequest<AuthTokensDto>
    {
        public string RefreshToken { get; set; }
    }
}
