using Livraria.IO.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Livraria.IO.Application.Interfaces
{
    public interface IEditoraAppService : IDisposable
    {
        void Registrar(EditoraViewModel editoraViewModel);
    }
}
