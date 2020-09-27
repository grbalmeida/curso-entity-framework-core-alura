using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        private static void RecuperarProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                foreach (var produto in produtos)
                {
                    Console.WriteLine($"Id: {produto.Id}");
                    Console.WriteLine($"Nome: {produto.Nome}");
                    Console.WriteLine($"Categoria: {produto.Categoria}");
                    Console.WriteLine($"Preço: {produto.PrecoUnitario}");
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }
    }
}
