using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Data
{
    public class storeContext : DbContext
    {
        public storeContext(DbContextOptions<storeContext> options) : base(options) { }

        public DbSet<Game> Game { get; set; }
    }
}
