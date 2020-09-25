using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                IList<Produto> produtos = repo.Produtos();

                Console.WriteLine($"Foram encontrados {produtos.Count} produto(s).");

                foreach (var produto in produtos)
                {
                    repo.Remover(produto);
                }
            }

            Console.ReadLine();
        }
    }
}
