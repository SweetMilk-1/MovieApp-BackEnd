using MediatR;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Models.Dto;
using MovieApp.Services.Security;

namespace MovieApp.Handlers.User.RefreshTokens
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokensRequest, AuthTokensDto>
    {
        MovieAppDbContext _dbContext;
        IJwtService _jwtService;
        ISessionService _sessionService;

        public RefreshTokenHandler(MovieAppDbContext context, IJwtService jwtService, ISessionService sessionService)
        {
            _dbContext = context;
            _jwtService = jwtService;
            _sessionService = sessionService;
        }

        public async Task<AuthTokensDto> Handle(RefreshTokensRequest request, CancellationToken cancellationToken)
        {
                
            var refreshTokenSessionId = _jwtService.GetSessionIdFromRefreshToken(request.RefreshToken);
            var user = await _sessionService.GetUser(refreshTokenSessionId);

            if (user == null)
            {
                throw new BadRequestException("Некорректный токен. Требуется повторная авторизация");
            }

            var sessionId = Guid.NewGuid();
            var accessToken = _jwtService.CreateAccessToken(new Models.Dto.UserJwtInfoDto(user.Id, user.Login, user.IsAdmin, sessionId));
            var refreshToken = _jwtService.CreateRefreshToken(sessionId);
            await _sessionService.SetSessionId(user.Id, sessionId);

            return new AuthTokensDto
            {
                UserId = user.Id,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
