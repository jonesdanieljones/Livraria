using System;

namespace Livraria.IO.Domain.Produtos.Events
{
    public class ProdutoRegistradoEvent : BaseProdutoEvent
    {
        public ProdutoRegistradoEvent(
            Guid id,
            string nome,
            DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            DataCadastro = dataCadastro;
            
            AggregateId = id;
        }
    }
}
