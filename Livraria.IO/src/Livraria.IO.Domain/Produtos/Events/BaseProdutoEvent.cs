using Livraria.IO.Domain.Core.Events;
using System;

namespace Livraria.IO.Domain.Produtos.Events
{
    public abstract class BaseProdutoEvent : Event
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public string DescricaoCurta { get; protected set; }
        public string DescricaoLonga { get; protected set; }
        public DateTime DataCadastro { get; protected set; }
    }
}
