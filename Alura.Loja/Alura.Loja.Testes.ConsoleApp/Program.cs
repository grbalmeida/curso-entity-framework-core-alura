using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // GravarUsandoAdoNet();
            GravarUsandoEntity();
            RecuperarProdutos();
            ExcluirProdutos();
            RecuperarProdutos();
            AtualizarProduto();
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAOEntity())
            {
                repo.Adicionar(p);
            }
        }

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
                    Console.WriteLine($"Preço: {produto.Preco}");
                    Console.WriteLine();
                }
            }

            Console.ReadLine();
        }

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

        private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();

            using (var repo = new ProdutoDAO())
            {
                Produto produto = repo.Produtos().First();

                produto.Nome = "Casino Royale - Editado";

                repo.Atualizar(produto);
            }

            RecuperarProdutos();
        }

    }
}
