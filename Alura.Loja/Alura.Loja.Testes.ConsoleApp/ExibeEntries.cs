using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
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
