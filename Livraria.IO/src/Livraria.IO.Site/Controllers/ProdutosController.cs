using Livraria.IO.Application.Interfaces;
using Livraria.IO.Application.ViewModels;
using Livraria.IO.Domain.Core.Notifications;
using Livraria.IO.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Livraria.IO.Site.Controllers
{
    [Route("")]
    public class ProdutosController : BaseController
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService,
                                 IDomainNotificationHandler<DomainNotification> notifications,
                                 IUser user) : base(notifications,user)
        {
            _produtoAppService = produtoAppService;
        }

        [Route("")]
        [Route("proximos-produtos")]
        public IActionResult Index()
        {
            return View(_produtoAppService.ObterTodos());
        }

        [Route("meus-produtos")]
        [Authorize(Policy = "PodeLerProdutos")]
        public IActionResult MeusProdutos()
        {
            return View(_produtoAppService.ObterProdutoPorEditora(EditoraId));
        }

        [Route("dados-do-produto/{id:guid}")]
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.ObterPorId(id.Value);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Route("novo-produto")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("novo-produto")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Create(ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel.EditoraId = EditoraId;
            _produtoAppService.Registrar(produtoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Produto registrado com sucesso!" : "error,Produto não registrado! Verifique as mensagens";

            return View(produtoViewModel);
        }

        [Route("editar-produto/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.ObterPorId(id.Value);

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.ObterProdutoPorEditora(EditoraId));
            }

            return View(produtoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("editar-produto/{id:guid}")]
        [Authorize(Policy = "PodeGravar")]
        public IActionResult Edit(ProdutoViewModel produtoViewModel)
        {
            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.ObterProdutoPorEditora(EditoraId));
            }

            if (!ModelState.IsValid) return View(produtoViewModel);

            produtoViewModel.EditoraId = EditoraId;
            _produtoAppService.Atualizar(produtoViewModel);

            ViewBag.RetornoPost = OperacaoValida() ? "success,Produto atualizado com sucesso!" : "error,Produto não ser atualizado! Verifique as mensagens";           
            produtoViewModel = _produtoAppService.ObterPorId(produtoViewModel.Id);
            

            return View(produtoViewModel);
        }

        [Authorize(Policy = "PodeGravar")]
        [Route("excluir-produto/{id:guid}")]
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = _produtoAppService.ObterPorId(id.Value);

            if (ValidarAutoridadeProduto(produtoViewModel))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.ObterProdutoPorEditora(EditoraId));
            }

            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        [Authorize(Policy = "PodeGravar")]
        [HttpPost, ActionName("Delete")]
        [Route("excluir-produto/{id:guid}")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            if (ValidarAutoridadeProduto(_produtoAppService.ObterPorId(id)))
            {
                return RedirectToAction("MeusProdutos", _produtoAppService.ObterProdutoPorEditora(EditoraId));
            }

            _produtoAppService.Excluir(id);
            return RedirectToAction("Index");
        }
        private bool ValidarAutoridadeProduto(ProdutoViewModel produtoViewModel)
        {
            return produtoViewModel.EditoraId != EditoraId;
        }

    }
}

