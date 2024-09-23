using MovieApp.Models.Dto;

namespace MovieApp.Services.Security
{
    public interface IJwtService
    {
        string CreateAccessToken(UserJwtInfoDto userJwtInfo);
        string CreateRefreshToken(Guid sessionId);
    }
}
