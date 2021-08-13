using ProjetoLivraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivraria.Repository.Interfaces
{
    public interface ILivrosRepository : IBaseRepository<Livros>
    {
        Livros ObterPorIsbn(string isbn);
        List<Livros> ObterPorAutor(string autor);
        List<Livros> ObterPorNome(string nome);
        List<Livros> ObterPorPreco(decimal precoMin, decimal precoMax);
        List<Livros> ObterPorData(DateTime dataMin, DateTime dataMax);
    }
}