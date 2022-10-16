using Microsoft.EntityFrameworkCore;
using mShop.Core.Data;
using msShop.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msShop.Catalogo.API.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly CatalogoContext _catalogoContext;
        public IUnitOfWork UnitOfWork => _catalogoContext;

        public ProdutoRepository(CatalogoContext catalogoContext)
        {
            _catalogoContext = catalogoContext;
        }
        public async Task<bool> AdicionarProduto(Produto produto)
        {
            await _catalogoContext.Produtos.AddAsync(produto);

            return await _catalogoContext.Commit();
        }

        public async Task<bool> AdicionarCategoria(Categoria categoria)
        {
            await _catalogoContext.Categorias.AddAsync(categoria);

            return await _catalogoContext.Commit();
        }

        public void AtualizarProduto(Produto produto)
        {
            _catalogoContext.Produtos.Update(produto);
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            return await _catalogoContext.Produtos.FindAsync(id);
        }

        public async Task<List<Produto>> ObterProdutosAVenda()
        {
            return await _catalogoContext.Produtos.Include(c => c.Categoria).Where(p => p.Ativo).AsNoTracking().ToListAsync();
        }
        public void Dispose()
        {
            _catalogoContext?.Dispose();
        }
    }
}
