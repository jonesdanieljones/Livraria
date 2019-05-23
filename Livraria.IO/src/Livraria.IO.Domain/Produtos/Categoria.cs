using Livraria.IO.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.IO.Domain.Produtos
{
    public class Categoria : Entity<Categoria>
    {
        public Categoria(Guid id)
        {
            Id = id;
        }

        public string Nome { get; private set; }

        // EF Propriedade de Navegação
        public virtual ICollection<Produto> Produtos { get; set; }

        // Construtor para o EF
        protected Categoria() { }

        public override bool EhValido()
        {
            return true;
        }
    }
}
