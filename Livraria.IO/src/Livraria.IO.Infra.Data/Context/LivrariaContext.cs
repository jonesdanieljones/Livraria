using Livraria.IO.Domain.Editoras;
using Livraria.IO.Domain.Produtos;
using Livraria.IO.Infra.Data.Extensions;
using Livraria.IO.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Livraria.IO.Infra.Data.Context
{
    public class LivrariaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Editora> Editoras { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ProdutoMapping());
            modelBuilder.AddConfiguration(new EditoraMapping());            
            modelBuilder.AddConfiguration(new CategoriaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }

    }
}
