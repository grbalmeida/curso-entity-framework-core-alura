using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Produto
            {
                Nome = "Suco de Laranja",
                Categoria = "Bebidas",
                PrecoUnitario = 8.79,
                Unidade = "Litros"
            };

            var p2 = new Produto
            {
                Nome = "Café",
                Categoria = "Bebidas",
                PrecoUnitario = 12.45,
                Unidade = "Gramas"
            };

            var p3 = new Produto
            {
                Nome = "Macarrão",
                Categoria = "Alimentos",
                PrecoUnitario = 4.23,
                Unidade = "Gramas"
            };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                // contexto.Promocoes.Add(promocaoDePascoa);

                var promocao = contexto.Promocoes.First();
                contexto.Promocoes.Remove(promocao);
                contexto.SaveChanges();
            }

            Console.ReadLine();
        }

        private static void UmParaMuitos()
        {
            var paoFrances = new Produto
            {
                Nome = "Pão Francês",
                PrecoUnitario = 0.40,
                Unidade = "Unidade",
                Categoria = "Padaria"
            };

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                var serviceProvider = contexto.GetInfrastructure();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(SqlLoggerProvider.Create());

                contexto.Compras.Add(compra);

                contexto.SaveChanges();
            }

            Console.ReadLine();
        }

    }
}
