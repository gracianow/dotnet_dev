using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace WebAppMvcMovie.Models
{
    [Table("movie")]
    public class Movie
    {
            public int MovieId { get; set; }
            public string Title { get; set; }
            [Display(Name = "Release Date")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }

        public class WebAppMvcMovieContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
        }

    }
}