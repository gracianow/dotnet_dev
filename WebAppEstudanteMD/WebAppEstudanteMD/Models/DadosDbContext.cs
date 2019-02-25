using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppEstudanteMD.Models
{
    public class DadosDbContext : DbContext
    {
        public DadosDbContext() : base("name=DadosDbContext")
        {

        }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Estudante> Estudantes { get; set; }
        public virtual DbSet<CursoEstudante> CursosEstudantes { get; set; }
    }
}