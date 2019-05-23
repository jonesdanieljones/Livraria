using Livraria.IO.Domain.Editoras;
using Livraria.IO.Domain.Editoras.Repository;
using Livraria.IO.Infra.Data.Context;

namespace Livraria.IO.Infra.Data.Repository
{
    public class EditoraRepository : Repository<Editora>, IEditoraRepository
    {
        public EditoraRepository(LivrariaContext context) : base(context)
        {
        }
    }
}
