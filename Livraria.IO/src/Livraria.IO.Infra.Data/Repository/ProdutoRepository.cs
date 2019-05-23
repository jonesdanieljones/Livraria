using Livraria.IO.Domain.Produtos;
using Livraria.IO.Domain.Produtos.Repository;
using Livraria.IO.Infra.Data.Context;
using System.Collections.Generic;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Livraria.IO.Infra.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(LivrariaContext context) : base(context)
        {

        }
        public override IEnumerable<Produto> ObterTodos()
        {
            var sql = "SELECT * FROM EVENTOS E " +
                      "WHERE E.EXCLUIDO = 0 " +
                      "ORDER BY E.DATAFIM DESC ";

            return Db.Database.GetDbConnection().Query<Produto>(sql);
        }
        public IEnumerable<Produto> ObterProdutoPorEditora(Guid editoraId)
        {
            var sql = @"SELECT * FROM Produtos P " +
                       "WHERE E.EXCLUIDO = 0 " +
                       "AND E.ORGANIZADORID = @oid " +
                       "ORDER BY E.DATAFIM DESC";

            //throw new Exception("Ocorreu um erro");
            return Db.Database.GetDbConnection().Query<Produto>(sql, new { oid = editoraId });
        }

        public override void Remover(Guid id)
        {
            var produto = ObterPorId(id);
            produto.ExcluirProduto();
            Atualizar(produto);
        }

        IEnumerable<Categoria> IProdutoRepository.ObterCategorias()
        {
            throw new NotImplementedException();
        }
    }
}
