using Microsoft.EntityFrameworkCore;
using ProjetoLivraria.Domain.Entities;
using ProjetoLivraria.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivraria.Repository.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Livros> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.HasIndex(c => c.Isbn).IsUnique();
            });
        }
    }
}
