using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppEmail.Models
{
    public class Contato
    {
        [Required, Display(Name = "Seu Nome")]
        public string Nome { get; set; }

        [Required, Display(Name = "Seu e-mail"), EmailAddress]
        public string Email { get; set; }

        [Required, Display(Name = "Assunto")]
        public string Assunto { get; set; }

        [Required]
        public string Mensagem { get; set; }
    }
}