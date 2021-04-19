using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using store.Data;
using System;
using System.Linq;

namespace store.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new storeContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<storeContext>>()))
            {
                // Look for any games.
                if (context.Game.Any())
                {
                    return;   // DB has been seeded
                }

                context.Game.AddRange(
                    new Game
                    {
                        Title = "Generic RPG",
                        Console = "SNES",
                        Genre = "Roleplaying",
                        Price = 14.99M
                    },

                    new Game
                    {
                        Title = "Shooter for Kids",
                        Console = "XBox",
                        Genre = "First Person Shooter",
                        Price = 59.99M
                    },

                    new Game
                    {
                        Title = "Not The Sim 3",
                        Console = "PlayStation",
                        Genre = "Simulation",
                        Price = 19.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
