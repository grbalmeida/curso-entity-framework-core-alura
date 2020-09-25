using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
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
                    Preco = 4.99
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

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            // Unchanged => quando a entidade não é alterada
            // Modified => quando a entidade é alterada
            // Added => quando a entidade é adicionada
            // Deleted => quando a entidade é removida
            // Detached => quando a entidade não está sendo monitorada pelo contexto.
            // Ex: Ao remover uma entidade adicionada e não persistida

            // Quando o Remove é chamado para um objeto que estava com o estado Added
            // O ChangeTracker simplesmente remove o objeto da lista de monitoramento
            // Ele não executa o DELETE no banco de dados

            Console.WriteLine("===========================");

            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }
        }

    }
}
