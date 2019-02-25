using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAlunos.Models
{
    [Table ("GrupoDetalhe")]
    public class GrupoDetalhe
    {
        [Key]
        public int GrupoDetalheId { get; set; }

        public int GrupoId { get; set; }

        public virtual Grupo Grupo { get; set; }

        public virtual Usuario Estudante { get; set; }

        public string GrupoEstudante { get { return string.Format("{0} / {1}", Grupo.Descricao, Estudante.NomeCompleto);} }

        public virtual ICollection<Notas> Notas { get; set; }
    }
}