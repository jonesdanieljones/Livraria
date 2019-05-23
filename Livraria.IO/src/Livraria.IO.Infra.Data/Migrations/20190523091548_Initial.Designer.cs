﻿// <auto-generated />
using System;
using Livraria.IO.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Livraria.IO.Infra.Data.Migrations
{
    [DbContext(typeof(LivrariaContext))]
    [Migration("20190523091548_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Livraria.IO.Domain.Editoras.Editora", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(11)")
                        .HasMaxLength(11);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Editoras");
                });

            modelBuilder.Entity("Livraria.IO.Domain.Produtos.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("Livraria.IO.Domain.Produtos.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CategoriaId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<string>("DescricaoCurta")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("DescricaoLonga")
                        .HasColumnType("varchar(max)");

                    b.Property<Guid>("EditoraId");

                    b.Property<Guid?>("EnderecoId");

                    b.Property<bool>("Excluido");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("EditoraId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Livraria.IO.Domain.Produtos.Produto", b =>
                {
                    b.HasOne("Livraria.IO.Domain.Produtos.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId");

                    b.HasOne("Livraria.IO.Domain.Editoras.Editora", "Editora")
                        .WithMany("Produtos")
                        .HasForeignKey("EditoraId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
