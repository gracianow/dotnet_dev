using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppEstudanteMD.Models
{
    [Table("CursosEstudantes")]
    public class CursoEstudante
    {
        [Key]
        public int CursoEstudanteId { get; set; }
        public int CursoId { get; set; }
        public int EstudanteId { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Estudante Estudante { get; set; }
    }
}