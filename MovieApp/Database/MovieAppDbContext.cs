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

    }
}
