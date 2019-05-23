using System;
using System.ComponentModel.DataAnnotations;

namespace Livraria.IO.Application.ViewModels
{
    public class EditoraViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requerido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CNPJ é requerido")]
        [StringLength(11)]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O e-mail é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }
    }
}
