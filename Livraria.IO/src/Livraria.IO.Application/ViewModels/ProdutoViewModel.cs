using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.IO.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
            Categoria = new CategoriaViewModel();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do Nome é {1}")]
        [MaxLength(150, ErrorMessage = "O tamanho máximo do Nome é {1}")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Display(Name = "Descricao curta do Produto")]
        public string DescricaoCurta { get; set; }

        [Display(Name = "Descricao longa do Produto")]
        public string DescricaoLonga { get; set; }

        [Display(Name = "Data de Cadastro")]
        [Required(ErrorMessage = "A data é requerida")]
        public DateTime DataCadastro { get; set; }
        
        public CategoriaViewModel Categoria { get; set; }
        public Guid CategoriaId { get; set; }
        public Guid EditoraId { get; set; }
    }
}
