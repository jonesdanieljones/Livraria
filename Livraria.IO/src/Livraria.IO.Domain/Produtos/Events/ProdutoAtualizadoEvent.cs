using System;

namespace Livraria.IO.Domain.Produtos.Events
{
    public class ProdutoAtualizadoEvent : BaseProdutoEvent
    {
        public ProdutoAtualizadoEvent(
            Guid id,
            string nome,
            string descCurta,
            string descLonga,
            DateTime dataCadastro)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descCurta;
            DescricaoLonga = descLonga;
            DataCadastro = dataCadastro;       
            AggregateId = id;
        }

    }
}
