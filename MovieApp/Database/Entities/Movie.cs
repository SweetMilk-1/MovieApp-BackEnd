namespace MovieApp.Database.Entities
{
    public class Movie
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string Description { get; set; }
        public string PgInfo { get; set; }
        public int? DurationInMinutes { get; set; }
        public  DateTime ReleaseDate { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
        public Guid CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow; 
    }
}
