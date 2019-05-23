using System;

namespace Livraria.IO.Domain.Produtos.Commands
{
    public class ExcluirProdutoCommand : BaseProdutoCommand
    {
        public ExcluirProdutoCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}