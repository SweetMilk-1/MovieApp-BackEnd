namespace MovieApp.Services.Security
{
    public interface IJwtService
    {
        string CreateAccessToken(string login, bool isAdmin, Guid sessionId);
        string CreateRefreshToken(Guid sessionId);
    }
}
