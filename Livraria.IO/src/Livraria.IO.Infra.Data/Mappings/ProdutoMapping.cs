using Livraria.IO.Domain.Produtos;
using Livraria.IO.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.IO.Infra.Data.Mappings
{
    public class ProdutoMapping : EntityTypeConfiguration<Produto>
    {
        public override void Map(EntityTypeBuilder<Produto> builder)
        {
            builder.Property(e => e.Nome)
               .HasColumnType("varchar(150)")
               .IsRequired();

            builder.Property(e => e.DescricaoCurta)
                .HasColumnType("varchar(150)");

            builder.Property(e => e.DescricaoLonga)
                .HasColumnType("varchar(max)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.Tags);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Produtos");

            builder.HasOne(e => e.Editora)
                .WithMany(o => o.Produtos)
                .HasForeignKey(e => e.EditoraId);

            builder.HasOne(e => e.Categoria)
                .WithMany(e => e.Produtos)
                .HasForeignKey(e => e.CategoriaId)
                .IsRequired(false);
        }
    }
}
