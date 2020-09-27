using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        private static void DeletedEDetached()
        {
            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                var produtos = contexto.Produtos.ToList();

                ExibeEntries(contexto.ChangeTracker.Entries());

                var novoProduto = new Produto
                {
                    Nome = "Sabão em pó",
                    Categoria = "Limpeza",
                    PrecoUnitario = 4.99
                };

                contexto.Produtos.Add(novoProduto);

                ExibeEntries(contexto.ChangeTracker.Entries());

                contexto.Produtos.Remove(novoProduto);

                ExibeEntries(contexto.ChangeTracker.Entries());

                //contexto.SaveChanges();

                var entry = contexto.Entry(novoProduto);
                Console.WriteLine(entry.Entity.ToString() + " - " + entry.State);

                ExibeEntries(contexto.ChangeTracker.Entries());

                Console.ReadLine();
            }
        }
    }
}
