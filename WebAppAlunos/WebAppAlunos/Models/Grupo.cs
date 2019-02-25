using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAlunos.Models
{

    [Table("Grupo")]
    public class Grupo
    {
        [Key]
        public int GrupoId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!", MinimumLength = 3)]
        [Index("GrupoDescricaoIndex", IsUnique = true)]
        public string  Descricao { get; set; }

        public int UserId { get; set; }

        public virtual Usuario Professor { get; set; }

        public virtual ICollection<GrupoDetalhe> GruposDetalhes { get; set; }
    }
}