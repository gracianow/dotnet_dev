using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLivroRepo.Models
{
    interface ILivroRepositorio : IDisposable
    {
        IEnumerable<Livro> GetLivros();
        Livro GetLivroPorID(int livroId);
        void InserirLivro(Livro livro);
        void DeletarLivro(int bookID);
        void AtualizaLivro(Livro livro);
        void Salvar();
    }
}
