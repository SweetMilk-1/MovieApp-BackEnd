using MovieApp.Database.Entities;
using MovieApp.Models.Common;

namespace MovieApp.Models.Dto
{
    public class MovieItemDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public string PgInfo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<DictionaryItemDto> Genres { get; set; }
    }
}
