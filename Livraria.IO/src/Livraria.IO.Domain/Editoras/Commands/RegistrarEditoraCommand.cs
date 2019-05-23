using Livraria.IO.Domain.Core.Commands;
using System;

namespace Livraria.IO.Domain.Editoras.Commands
{
    public class RegistrarEditoraCommand : Command
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }

        public RegistrarEditoraCommand(Guid id, string nome, string cnpj, string email)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
        }
    }
}
