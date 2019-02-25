using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAlunos.Models
{
    [Table("Notas")]
    public class Notas
    {
        [Key]
        public int NotaId { get; set; }

        public int GrupoDetalheId { get; set; }

        [Required(ErrorMessage = "Digite o valor no campo {0}!")]
        [Range(0, 1, ErrorMessage = "O campo {0} contém valores entre {1} e {2}")]
        [DisplayFormat(DataFormatString ="{0:P2}", ApplyFormatInEditMode = false)]
        public float Percentual { get; set; }

        [Required(ErrorMessage = "Digite o valor no campo {0}!")]
        [Range(0, 1, ErrorMessage = "O campo {0} contém valores entre {1} e {2}")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float Nota { get; set; }

        public virtual GrupoDetalhe GruposDetalhes{ get; set; }
    }
}