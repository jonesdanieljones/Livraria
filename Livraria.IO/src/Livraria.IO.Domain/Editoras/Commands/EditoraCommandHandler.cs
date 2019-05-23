using Livraria.IO.Domain.CommandHandlers;
using Livraria.IO.Domain.Core.Bus;
using Livraria.IO.Domain.Core.Events;
using Livraria.IO.Domain.Core.Notifications;
using Livraria.IO.Domain.Editoras.Events;
using Livraria.IO.Domain.Editoras.Repository;
using Livraria.IO.Domain.Interfaces;
using System.Linq;

namespace Livraria.IO.Domain.Editoras.Commands
{
    public class EditoraCommandHandler : CommandHandler,
        IHandler<RegistrarEditoraCommand>        
    {
        private readonly IBus _bus;
        private readonly IEditoraRepository _editoraRepository;

        public EditoraCommandHandler(
            IUnitOfWork uow,
            IBus bus,
            IDomainNotificationHandler<DomainNotification> notifications,
            IEditoraRepository editoraRepository) : base(uow, bus, notifications)
        {
            _bus = bus;
            _editoraRepository = editoraRepository;
        }
        public void Handle(RegistrarEditoraCommand message)
        {
            var editora = new Editora(message.Id, message.Nome, message.CNPJ, message.Email);

            if (!editora.EhValido())
            {
                NotificarValidacoesErro(editora.ValidationResult);
                return;
            }

            var editoraExistente = _editoraRepository.Buscar(o => o.CNPJ == editora.CNPJ || o.Email == editora.Email);

            if (editoraExistente.Any())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "CPF ou e-mail já utilizados"));
            }

            _editoraRepository.Adicionar(editora);

            if (Commit())
            {
                _bus.RaiseEvent(new EditoraRegistradoEvent(editora.Id, editora.Nome, editora.CNPJ, editora.Email));
            }
        }
    }
}
