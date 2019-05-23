using Livraria.IO.Domain.Core.Models;
using Livraria.IO.Domain.Produtos;
using System;
using System.Collections.Generic;

namespace Livraria.IO.Domain.Editoras
{
    public class Editora : Entity<Editora>
    {
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }
        public Editora(Guid id, string nome, string cnpj, string email)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
        }

        //EF Construtor
        protected Editora() { }
        //EF Propriedade de Navegação
        public virtual ICollection<Produto> Produtos { get; set; }
        public override bool EhValido()
        {
            return true;
        }

    }
}
