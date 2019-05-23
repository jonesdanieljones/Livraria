using Livraria.IO.Domain.Core.Events;
using System;

namespace Livraria.IO.Domain.Editoras.Events
{
    public class EditoraRegistradoEvent : Event
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public string Email { get; private set; }

        public EditoraRegistradoEvent(Guid id, string nome, string cnpj, string email)
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Email = email;
        }
    }
}
