using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorMovie.Modelos;

namespace RazorMovie.Data
{
    public class RazorMovieContext : DbContext
    {
        public RazorMovieContext (DbContextOptions<RazorMovieContext> options)
            : base(options)
        {
        }

        public DbSet<RazorMovie.Modelos.Movie> Movie { get; set; }
    }
}
