using Livraria.IO.Domain.Core.Commands;
using Livraria.IO.Domain.Interfaces;
using Livraria.IO.Infra.Data.Context;

namespace Livraria.IO.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LivrariaContext _context;

        public UnitOfWork(LivrariaContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
