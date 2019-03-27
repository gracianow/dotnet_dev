using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcLivroRepo.Models
{
    public class LivroContext : DbContext
    {
        public LivroContext()
            : base("name=LivrariaDbContext")
        {
        }

        public DbSet<Livro> Livros { get; set; }
    }
}