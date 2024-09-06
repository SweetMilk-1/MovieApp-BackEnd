using Microsoft.EntityFrameworkCore;
using MovieApp.Models.Entities;

namespace MovieApp
{
    public class MovieAppDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        

    }
}
