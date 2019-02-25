using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppEstudanteMD.Models
{
    [Table("Cursos")]
    public class Curso
    {
        public Curso()
        {
            this.Estudantes = new HashSet<Estudante>();
        }
        [Key]
        public int CursoId { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Creditos { get; set; }
        public virtual ICollection<Estudante> Estudantes { get; set; }
    }
}