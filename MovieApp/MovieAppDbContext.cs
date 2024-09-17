using Microsoft.EntityFrameworkCore;
using MovieApp.Models.Entities;

namespace MovieApp
{
    public class MovieAppDbContext : DbContext
    {
        public MovieAppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        
    }
}
