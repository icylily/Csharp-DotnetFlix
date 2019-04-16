using Microsoft.EntityFrameworkCore;

namespace DotnetFlix.Models
{
    public class FlixContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public FlixContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}