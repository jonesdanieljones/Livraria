using Livraria.IO.Domain.Core.Commands;
using System;

namespace Livraria.IO.Domain.Produtos.Commands
{
    public abstract class BaseProdutoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string DescricaoCurta { get; protected set; }
        public string DescricaoLonga { get; protected set; }
        public DateTime DataCadastro { get; protected set; }        
        public Guid EditoraId { get; protected set; }
        public Guid CategoriaId { get; protected set; }
    }
}