namespace MovieApp.Handlers.User.Authentication
{
    public class AuthTokensDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}