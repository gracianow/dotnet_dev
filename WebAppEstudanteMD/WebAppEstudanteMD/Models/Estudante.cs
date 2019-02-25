using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppEstudanteMD.Models
{
    [Table("Estudantes")]
    public class Estudante
    {
        public Estudante()
        {
            this.Cursos = new HashSet<Curso>();
        }
        [Key]
        public int EstudanteId { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Idade { get; set; }
        public string Sexo { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
    }
}