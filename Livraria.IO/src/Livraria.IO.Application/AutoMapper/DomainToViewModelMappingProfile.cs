using AutoMapper;
using Livraria.IO.Application.ViewModels;
using Livraria.IO.Domain.Editoras;
using Livraria.IO.Domain.Produtos;

namespace Livraria.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();            
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<Editora, EditoraViewModel>();
        }
    }
}
