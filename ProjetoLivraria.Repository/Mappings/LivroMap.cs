using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjetoLivraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLivraria.Repository.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livros>
    {
        public void Configure(EntityTypeBuilder<Livros> builder)
        {
            #region Tabela
            builder.ToTable("LIVROS");
            #endregion
            #region Chave Primária
            builder.HasKey(c => c.IdLivro);
            #endregion
            #region Campos da Tabela
            builder.Property(c => c.IdLivro)
                .HasColumnName("IDLIVRO");

            builder.Property(c => c.Isbn)
                .HasColumnName("ISBN")
                .HasMaxLength(13)
                .IsRequired();
                

            builder.Property(c => c.Autor)
                .HasColumnName("AUTOR")
                .HasMaxLength(150)
                .IsRequired();


            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(c => c.Preco)
                .HasColumnName("PRECO")
                .IsRequired();

            builder.Property(c => c.DataPublicacao)
                .HasColumnName("DATAPUBLICACAO")
                .HasColumnType("datetime")
                .IsRequired();
            #endregion
        }
    }
}
