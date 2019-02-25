using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEstudanteMD.Models
{
    public class EstudantesViewModel
    {
        public int EstudanteId { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Idade { get; set; }
        public string Sexo { get; set; }
        public List<CheckBoxViewModel> Cursos { get; set; }
    }
}