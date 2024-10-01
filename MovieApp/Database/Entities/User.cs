namespace MovieApp.Database.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
        public string? ImagePath { get; set; }
    }
}
