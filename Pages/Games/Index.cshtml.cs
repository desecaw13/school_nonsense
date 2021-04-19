using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using store.Data;
using store.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace store.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly storeContext _context;

        public IndexModel(storeContext context)
        {
            _context = context;
        }

        public IList<Game> Game { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameGenre { get; set; }

        public SelectList Consoles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameConsole { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> consoleQuery = from c in _context.Game orderby c.Console select c.Console;
            IQueryable<string> genreQuery = from g in _context.Game orderby g.Genre select g.Genre;

            var games = from g in _context.Game select g;

            if (!string.IsNullOrEmpty(SearchString))
            {
                games = games.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(GameConsole))
            {
                games = games.Where(x => x.Console == GameConsole);
            }
            Consoles = new SelectList(await consoleQuery.Distinct().ToListAsync());

            if (!string.IsNullOrEmpty(GameGenre))
            {
                games = games.Where(x => x.Genre == GameGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Game = await games.ToListAsync();
        }
    }
}
