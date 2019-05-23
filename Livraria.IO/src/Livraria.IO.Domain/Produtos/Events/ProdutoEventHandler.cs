using Livraria.IO.Domain.Core.Events;
using System;

namespace Livraria.IO.Domain.Produtos.Events
{
    public class ProdutoEventHandler :
        IHandler<ProdutoRegistradoEvent>,
        IHandler<ProdutoAtualizadoEvent>,
        IHandler<ProdutoExcluidoEvent>
    {
        public void Handle(ProdutoRegistradoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Registrado com sucesso");
        }

        public void Handle(ProdutoAtualizadoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Atualizado com sucesso");
        }

        public void Handle(ProdutoExcluidoEvent message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto Excluido com sucesso");
        }  
    }
}
