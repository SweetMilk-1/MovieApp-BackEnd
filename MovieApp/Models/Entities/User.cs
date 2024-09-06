namespace MovieApp.Models.Entities
{
    public class User
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsApproved { get; set; } = false;
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime CreateDate { get; private set; } = DateTime.UtcNow;
        public string? PhotoUrl { get; set; }
    }
}
