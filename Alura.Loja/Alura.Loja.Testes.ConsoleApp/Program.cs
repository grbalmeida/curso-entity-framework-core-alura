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
                var produtos = contexto.Produtos.ToList();

                foreach (var produto in produtos)
                {
                    Console.WriteLine(produto);
                }

                Console.WriteLine("===========================");

                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                // UNCHANGED

                var p1 = produtos.Last();
                p1.Nome = "008 - O Espião Que Me Amava";

                // MODIFIED

                foreach (var e in contexto.ChangeTracker.Entries())
                {
                    Console.WriteLine(e.State);
                }

                Console.ReadLine();
            }
        }

    }
}
