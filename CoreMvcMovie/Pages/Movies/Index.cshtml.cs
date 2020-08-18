using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CoreMvcMovie.Data;
using CoreMvcMovie.Models;

namespace CoreMvcMovie.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly CoreMvcMovie.Data.CoreMvcMovieContext _context;

        public IndexModel(CoreMvcMovie.Data.CoreMvcMovieContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
