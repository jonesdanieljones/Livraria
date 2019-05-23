using Livraria.IO.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.IO.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        void Registrar(ProdutoViewModel produtoViewModel);
        IEnumerable<ProdutoViewModel> ObterTodos();
        IEnumerable<ProdutoViewModel> ObterProdutoPorEditora(Guid editoraId);
        ProdutoViewModel ObterPorId(Guid id);
        void Atualizar(ProdutoViewModel produtoViewModel);
        void Excluir(Guid id);
    }
}
