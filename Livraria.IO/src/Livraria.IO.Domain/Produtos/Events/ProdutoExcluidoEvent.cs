using System;

namespace Livraria.IO.Domain.Produtos.Events
{
    public class ProdutoExcluidoEvent : BaseProdutoEvent
    {
        public ProdutoExcluidoEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}
