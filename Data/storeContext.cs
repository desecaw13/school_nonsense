using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using store.Models;

namespace store.Data
{
    public class storeContext : DbContext
    {
        public storeContext (DbContextOptions<storeContext> options)
            : base(options)
        {
        }

        public DbSet<store.Models.Game> Game { get; set; }
    }
}
