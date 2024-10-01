namespace MovieApp.Database.Entities
{
    public class Actor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string? Bio { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public string? ImagePath { get; set; }
    }
}
