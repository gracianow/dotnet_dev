using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAppAlunos.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage ="O campo {0} é obrigatório!")]
        [StringLength(100, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!")]
        [DataType(DataType.EmailAddress)]
        [Index("UsernameIndex", IsUnique = true)]
        public string UserName { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(50, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!")]
        public string Sobrenome { get; set; }

        [Display(Name = "Usuário")]
        public string NomeCompleto { get { return string.Format("{0} {1}", this.Nome, this.Sobrenome); } }

        [Display(Name = "Fone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório!")]
        [StringLength(20, ErrorMessage = "O campo {0} pode ter no máximo {1} e no mínimo {2} carácter!", MinimumLength = 10)]
        public string Fone { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Display(Name = "Foto")]
        [DataType(DataType.ImageUrl)]
        public string Foto { get; set; }

        [Display(Name = "Estudante")]
        public bool Estudante { get; set; }

        [Display(Name = "Professor")]
        public bool Professor { get; set; }

        public virtual ICollection<Grupo> Grupos { get; set; }

        public virtual ICollection<GrupoDetalhe> GruposDetalhes { get; set; }
    }
}