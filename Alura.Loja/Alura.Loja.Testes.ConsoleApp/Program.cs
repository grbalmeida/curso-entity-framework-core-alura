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
            // GravarUsandoEntity();
            // RecuperarProdutos();
            // ExcluirProdutos();
            // RecuperarProdutos();
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

            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p);
                contexto.SaveChanges();
            }
        }

        private static void RecuperarProdutos()
        {
            using (var contexto = new LojaContext())
            {
                IList<Produto> produtos = contexto.Produtos.ToList();

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
            using (var contexto = new LojaContext())
            {
                IList<Produto> produtos = contexto.Produtos.ToList();

                Console.WriteLine($"Foram encontrados {produtos.Count} produto(s).");

                foreach (var produto in produtos)
                {
                    contexto.Produtos.Remove(produto);
                }

                contexto.SaveChanges();
            }

            Console.ReadLine();
        }

        private static void AtualizarProduto()
        {
            GravarUsandoEntity();
            RecuperarProdutos();

            using (var contexto = new LojaContext())
            {
                Produto produto = contexto.Produtos.First();

                produto.Nome = "Casino Royale - Editado";

                contexto.Produtos.Update(produto);

                contexto.SaveChanges();
            }

            RecuperarProdutos();
        }

    }
}
