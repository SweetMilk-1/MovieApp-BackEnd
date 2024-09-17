using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApp.Database;
using MovieApp.Infrastucture.Exceptions;
using MovieApp.Services.Security;

namespace MovieApp.Handlers.User.Authentication
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationRequest, AuthenticationResponse>
    {
        private readonly MovieAppDbContext _dbContext;
        private readonly IJwtService _jwtService;
        private readonly ISessionService _sessionService;
        private readonly ICryptoService _cryptoService;

        public AuthenticationHandler(MovieAppDbContext dbContext, IJwtService jwtService, ISessionService sessionService, ICryptoService cryptoService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
            _sessionService = sessionService;
            _cryptoService = cryptoService;
        }

        public async Task<AuthenticationResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.AsNoTracking()
                .FirstOrDefaultAsync(x => 
                    x.Login == request.Login 
                    && x.PasswordHash == _cryptoService.GetHashFromString(request.Password)
                    && x.IsApproved);

            if (user == null) {
                throw new BadRequestException("Неправльный логин или пароль");
            }

            var sessionId = Guid.NewGuid();
            var accessToken = _jwtService.CreateAccessToken(user.Login, user.IsAdmin, sessionId);
            var refreshToken = _jwtService.CreateRefreshToken(sessionId);
            await _sessionService.SetSessionId(user.Id, sessionId);

            return new AuthenticationResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
