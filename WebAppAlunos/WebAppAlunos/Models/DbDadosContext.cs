using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppAlunos.Models
{
    public class DbDadosContext : DbContext
    {

        public DbDadosContext() : base("DefaultConnection")
        {
            
        }


        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public System.Data.Entity.DbSet<WebAppAlunos.Models.Usuario> Usuarios { get; set; }
    }
}