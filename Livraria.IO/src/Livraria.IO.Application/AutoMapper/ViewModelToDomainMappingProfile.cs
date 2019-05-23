using System;
using AutoMapper;
using Livraria.IO.Application.ViewModels;
using Livraria.IO.Domain.Editoras.Commands;
using Livraria.IO.Domain.Produtos.Commands;

namespace Livraria.IO.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, RegistrarProdutoCommand>()
                .ConstructUsing(c => new RegistrarProdutoCommand(c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.DataCadastro, c.EditoraId, c.CategoriaId));

            CreateMap<ProdutoViewModel, AtualizarProdutoCommand>()
                .ConstructUsing(c => new AtualizarProdutoCommand(c.Id, c.Nome, c.DescricaoCurta, c.DescricaoLonga, c.EditoraId, c.CategoriaId));

            CreateMap<ProdutoViewModel, ExcluirProdutoCommand>()
                .ConstructUsing(c => new ExcluirProdutoCommand(c.Id));

            // Editora
            CreateMap<EditoraViewModel, RegistrarEditoraCommand>()
                .ConstructUsing(c => new RegistrarEditoraCommand(c.Id, c.Nome, c.CNPJ, c.Email));
        }
    }
}
