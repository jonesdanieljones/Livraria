using Livraria.IO.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.IO.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
