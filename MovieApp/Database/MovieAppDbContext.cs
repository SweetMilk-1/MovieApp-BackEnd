using Microsoft.EntityFrameworkCore;
using MovieApp.Database.Entities;

namespace MovieApp.Database
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<UserSession> UserSessions => Set<UserSession>();
        public DbSet<Genre> Genres => Set<Genre>();
        public DbSet<Actor> Actors => Set<Actor>();
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
              .HasOne(r => r.CreatedByUser)
              .WithMany(u => u.OwnReviews)
              .HasForeignKey(r => r.CreatedByUserId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Review>()
                .HasMany(r => r.LikeUsers)
                .WithMany(m => m.LikeReviews);
        }
    }
}
