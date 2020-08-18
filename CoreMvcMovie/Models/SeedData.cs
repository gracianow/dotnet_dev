using CoreMvcMovie.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CoreMvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CoreMvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Rating = "B",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "C",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "C",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "E",
                        Price = 3.99M
                    },

                    new Movie
                    {
                        Title = "Forrest Gump",
                        ReleaseDate = DateTime.Parse("1994-4-1"),
                        Genre = "Drama",
                        Rating = "A",
                        Price = 19.99M
                    },

                    new Movie
                    {
                        Title = "King Kong ",
                        ReleaseDate = DateTime.Parse("2006-12-15"),
                        Genre = "Aventura",
                        Rating = "A",
                        Price = 17.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
