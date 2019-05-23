using Livraria.IO.Domain.CommandHandlers;
using Livraria.IO.Domain.Core.Bus;
using Livraria.IO.Domain.Core.Events;
using Livraria.IO.Domain.Core.Notifications;
using Livraria.IO.Domain.Interfaces;
using Livraria.IO.Domain.Produtos.Events;
using Livraria.IO.Domain.Produtos.Repository;
using System;

namespace Livraria.IO.Domain.Produtos.Commands
{
    public class ProdutoCommandHandler : CommandHandler,
        IHandler<RegistrarProdutoCommand>,
        IHandler<AtualizarProdutoCommand>,
        IHandler<ExcluirProdutoCommand>

    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IBus _bus;
        private readonly IUser _user;

        public ProdutoCommandHandler(IProdutoRepository produtoRepository,
                                    IUnitOfWork uow,
                                    IBus bus,
                                    IDomainNotificationHandler<DomainNotification> notifications, 
                                    IUser user) : base(uow,bus,notifications)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
            _user = user;
        }

        public void Handle(RegistrarProdutoCommand message)
        {
            var produto = Produto.ProdutoFactory.NovoProdutoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                message.DescricaoLonga, message.DataCadastro, message.EditoraId, message.CategoriaId);

            if (!ProdutoValido(produto)) return;

            // TODO:
            // Validacoes de negocio!
            // Editora pode registrar produto?

            _produtoRepository.Adicionar(produto);

            if (Commit())
            {
                _bus.RaiseEvent(new ProdutoRegistradoEvent(produto.Id, 
                                                           produto.Nome, 
                                                           produto.DataCadastro));
            }
        }

        public void Handle(AtualizarProdutoCommand message)
        {
            var produtoAtual = _produtoRepository.ObterPorId(message.Id);

            if (!ProdutoExistente(message.Id, message.MessageType)) return;

            if (produtoAtual.EditoraId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto não pertencente ao Produto"));
                return;
            }

            var produto = Produto.ProdutoFactory.NovoProdutoCompleto(message.Id, message.Nome, message.DescricaoCurta,
                message.DescricaoLonga, message.DataCadastro, message.EditoraId, message.CategoriaId);

            if (string.IsNullOrEmpty(produto.Nome) && produto.EditoraId == null)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType,"Não é possivel atualizar um produto sem informar a Editora"));
                return;
            }

            if (!ProdutoValido(produto)) return;

            _produtoRepository.Atualizar(produto);

            if (Commit())
            {
                _bus.RaiseEvent(new ProdutoAtualizadoEvent(produto.Id, produto.Nome, produto.DescricaoCurta, produto.DescricaoLonga, produto.DataCadastro));
            }
        }

        public void Handle(ExcluirProdutoCommand message)
        {
            if (!ProdutoExistente(message.Id, message.MessageType)) return;
            var produtoAtual = _produtoRepository.ObterPorId(message.Id);

            if (produtoAtual.EditoraId != _user.GetUserId())
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, "Produto não pertencente a Editora"));
                return;
            }

            // Validacoes de negocio
            produtoAtual.ExcluirProduto();

            _produtoRepository.Atualizar(produtoAtual);

            if (Commit())
            {
                _bus.RaiseEvent(new ProdutoExcluidoEvent(message.Id));
            }
        }

        private bool ProdutoValido(Produto produto)
        {
            if (produto.EhValido()) return true;

            NotificarValidacoesErro(produto.ValidationResult);
            return false;
        }

        private bool ProdutoExistente(Guid id, string messageType)
        {
            var produto = _produtoRepository.ObterPorId(id);
            if (produto != null) return true;
            _bus.RaiseEvent(new DomainNotification(messageType, "Produto não encontrado."));
            return false;
        }
    }
}