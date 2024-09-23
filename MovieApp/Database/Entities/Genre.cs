namespace MovieApp.Database.Entities
{
    public class Genre
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Name { get; set; }

        public IEnumerable<Movie> Movies { get; set; }
    }
}
