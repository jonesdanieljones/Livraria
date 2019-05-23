using Livraria.IO.Domain.Core.Events;

namespace Livraria.IO.Domain.Editoras.Events
{
    public class EditoraEventHandler :
        IHandler<EditoraRegistradoEvent>
    {
        public void Handle(EditoraRegistradoEvent message)
        {
            // TODO: Enviar um email?
        }
    }
}
