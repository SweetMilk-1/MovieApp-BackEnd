using MovieApp.Database.Entities;

namespace MovieApp.Models.Dto
{
    public class ReviewDto
    {
        public Guid? Id { get; set; } = Guid.NewGuid();
        public Guid MovieId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public int Grade { get; set; }
        public string? Text { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
