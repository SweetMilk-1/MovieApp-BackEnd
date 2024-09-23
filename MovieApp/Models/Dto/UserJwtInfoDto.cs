namespace MovieApp.Models.Dto
{
    public class UserJwtInfoDto
    {
        public UserJwtInfoDto(Guid userId, string login, bool isAdmin, Guid sessionId)
        {
            UserId = userId;
            Login = login;
            IsAdmin = isAdmin;
            SessionId = sessionId;
        }

        public Guid UserId { get; }
        public string Login { get; }
        public bool IsAdmin { get; }
        public Guid SessionId { get; }
    }
}
