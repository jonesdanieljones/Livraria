using System;

namespace Livraria.IO.Domain.Produtos.Commands
{
    public class RegistrarProdutoCommand : BaseProdutoCommand
    {
        public RegistrarProdutoCommand(
            string nome,
            string descricaoCurta,
            string descricaoLonga,
            DateTime dataCadastro,            
            Guid editoraId,
            Guid categoriaId            
            )
        {
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataCadastro = dataCadastro;
            EditoraId = editoraId;
            CategoriaId = categoriaId;
        }
    }
}