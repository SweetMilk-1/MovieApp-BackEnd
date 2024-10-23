namespace MovieApp.Services.Security
{
    public interface ISessionService
    {
        Task<Guid?> GetSessionId(Guid userId);
        Task SetSessionId(Guid userId, Guid sessionId);
        Task<Database.Entities.User?> GetUser(Guid sessionId);
    }
}
