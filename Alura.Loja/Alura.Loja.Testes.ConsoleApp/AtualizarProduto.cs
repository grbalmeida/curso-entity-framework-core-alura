using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
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
