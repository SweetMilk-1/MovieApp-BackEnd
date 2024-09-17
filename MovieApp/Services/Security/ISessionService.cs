namespace MovieApp.Services.Security
{
    public interface ISessionService
    {
        Task<Guid?> GetSessionId(Guid userId);
        Task SetSessionId(Guid userId, Guid sessionId);
    }
}
