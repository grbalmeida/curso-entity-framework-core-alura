namespace Alura.Loja.Testes.ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
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
        }

    }
}
