using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class ProdutoDAOEntity : IProdutoDAO, IDisposable
    {
        private LojaContext _contexto;

        public ProdutoDAOEntity()
        {
            _contexto = new LojaContext();
        }

        public void Adicionar(Produto p)
        {
            _contexto.Produtos.Add(p);
            _contexto.SaveChanges();
        }

        public void Atualizar(Produto p)
        {
            _contexto.Produtos.Update(p);
            _contexto.SaveChanges();
        }

        public IList<Produto> Produtos()
        {
            return _contexto.Produtos.ToList();
        }

        public void Remover(Produto p)
        {
            _contexto.Produtos.Remove(p);
            _contexto.SaveChanges();
        }

        public void Dispose()
        {
            _contexto?.Dispose();
        }
    }
}
