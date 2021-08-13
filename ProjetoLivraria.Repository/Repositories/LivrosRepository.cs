using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Domain.Entities;
using ProjetoLivraria.Repository.Contexts;
using ProjetoLivraria.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivraria.Repository.Repositories
{
    public class LivrosRepository : ILivrosRepository
    {
        private SqlServerContext context;

        public LivrosRepository(SqlServerContext context)
        {
            this.context = context;
        }

        public void Inserir(Livros obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Alterar(Livros obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Excluir(Livros obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public List<Livros> ObterTodos()
        {
            return context.Livros
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public Livros ObterPorId(Guid id)
        {
            return context.Livros.Find(id);
        }

        public Livros ObterPorIsbn(string isbn)
        {
            return context.Livros.FirstOrDefault(c => c.Isbn.Equals(isbn));
        }

        public List<Livros> ObterPorAutor(string autor)
        {
            return context.Livros
                .Where(c => c.Autor.Contains(autor))
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public List<Livros> ObterPorNome(string nome)
        {
            return context.Livros
                .Where(c => c.Nome.Contains(nome))
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public List<Livros> ObterPorPreco(decimal precoMin, decimal precoMax)
        {
            return context.Livros
                .Where(c => c.Preco >= precoMin && c.Preco <= precoMax)
                .OrderBy(c => c.Nome)
                .ToList();
        }

        public List<Livros> ObterPorData(DateTime dataMin, DateTime dataMax)
        {
            return context.Livros
                .Where(c => c.DataPublicacao >= dataMin && c.DataPublicacao <= dataMax)
                .OrderBy(c => c.Nome)
                .ToList();
        }
    }
}
