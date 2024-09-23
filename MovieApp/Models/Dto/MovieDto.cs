using MovieApp.Database.Entities;

namespace MovieApp.Models.Dto
{
    public class MovieDto
    {
        public Guid? Id { get; set; } //Ignore for mapping
        public string Title { get; set; }
        public string Description { get; set; }
        public string PgInfo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<DictionaryItemDto>? Actors { get; set; }
        public IEnumerable<DictionaryItemDto>? Genres { get; set; }
        public Guid CreatedByUserId { get; set; } //Ignore for mapping
        public DateTime CreatedAt { get; set; } //Ignore for mapping
    }
}
