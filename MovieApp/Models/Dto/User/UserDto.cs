namespace MovieApp.Models.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public string Login { get;set; }
        public string? PhotoUrl { get; set; }
    }
}
