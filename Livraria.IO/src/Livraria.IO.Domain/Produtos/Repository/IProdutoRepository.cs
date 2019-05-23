using Livraria.IO.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Livraria.IO.Domain.Produtos.Repository
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        IEnumerable<Produto> ObterProdutoPorEditora(Guid editoraId);
        IEnumerable<Categoria> ObterCategorias();
    }
}
