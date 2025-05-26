namespace MovieApp.Database.Entities
{
    public class Review
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        
        public Guid MovieId { get; set; }
        public Guid CreatedByUserId { get; set; }

        public int Grade { get; set; }
        public string? Text { get; set; }
        public IEnumerable<User> LikeUsers { get; set; }
        public Movie Movie { get; set; }
        public User CreatedByUser { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
