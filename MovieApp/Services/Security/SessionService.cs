using Microsoft.EntityFrameworkCore;
using MovieApp.Database;

namespace MovieApp.Services.Security
{
    public class SessionService : ISessionService
    {
        private readonly MovieAppDbContext _dbContext;

        public SessionService(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid?> GetSessionId(Guid userId)
        {
            return (await _dbContext.UserSessions.FirstOrDefaultAsync(s => s.UserId == userId))?.SessionId;
        }

        public async Task SetSessionId(Guid userId, Guid sessionId)
        {
            var userSession = _dbContext.UserSessions.FirstOrDefault(s => s.UserId == userId);
            if (userSession != null)
            {
                userSession.SessionId = sessionId;
            }
            else
            {
                _dbContext.UserSessions.Add(
                    new Database.Entities.UserSession
                    {
                        UserId = userId,
                        SessionId = sessionId
                    });
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
