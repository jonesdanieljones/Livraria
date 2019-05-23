using System;
namespace Livraria.IO.Domain.Produtos.Commands
{
    public class AtualizarProdutoCommand : BaseProdutoCommand
    {
        public AtualizarProdutoCommand(
            Guid id,
            string nome,
            string descCurta,
            string descLonga,           
            Guid editoraId,
            Guid categoriaId)
        {
            Id = id;
            Nome = nome;
            DescricaoCurta = descCurta;
            DescricaoLonga = descLonga;            
            EditoraId = editoraId;
            CategoriaId = categoriaId;
        }
    }
}