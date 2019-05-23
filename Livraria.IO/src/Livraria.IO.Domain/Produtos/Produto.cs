using FluentValidation;
using Livraria.IO.Domain.Core.Models;
using Livraria.IO.Domain.Editoras;
using System;
using System.Collections.Generic;

namespace Livraria.IO.Domain.Produtos
{
    public class Produto : Entity<Produto>
    {
        public Produto(
            string nome,
            string descricaoCurta,
            string descricaoLonga,
            DateTime dataCadastro
            )
        {
            Id = Guid.NewGuid();
            Nome = nome;
            DescricaoCurta = descricaoCurta;
            DescricaoLonga = descricaoLonga;
            DataCadastro = dataCadastro;
        }
        private Produto() {}

        public string Nome { get; set; }
        public string DescricaoCurta { get; private set; }
        public string DescricaoLonga { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool Excluido { get; private set; }
        public ICollection<Tags> Tags { get; private set; }
        public Guid? CategoriaId { get; private set; }
        public Guid? EnderecoId { get; private set; }
        public Guid EditoraId { get; private set; }
        public virtual Categoria Categoria { get; private set; }      
        public virtual Editora Editora { get; private set; }
        public void AtribuirCategoria(Categoria categoria)
        {
            if (!categoria.EhValido()) return;
            Categoria = categoria;
        }
        public void ExcluirProduto()
        {
            // TODO: Deve validar alguma regra?
            Excluido = true;
        }

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }
        private void Validar()
        {
            ValidarNome();                                              
            ValidationResult = Validate(this);
        }
        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do produto precisa ser fornecido")
                .Length(2, 150).WithMessage("O nome do produto precisa ter entre 2 e 150 caracteres");
        }

        public static class ProdutoFactory
        {
            public static Produto NovoProdutoCompleto(Guid id, string nome, string descCurta, string descLonga, DateTime dataCadastro, Guid editoraId, Guid categoriaId)
            {
                var produto = new Produto()
                {
                    Id = id,
                    Nome = nome,
                    DescricaoCurta = descCurta,
                    DescricaoLonga = descLonga,
                    DataCadastro = dataCadastro,
                    EditoraId = editoraId,
                    CategoriaId = categoriaId
                };
                return produto;
            }
        }
    }
}
