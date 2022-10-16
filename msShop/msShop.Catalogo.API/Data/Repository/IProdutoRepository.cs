using msShop.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msShop.Catalogo.API.Data.Repository
{
    public interface IProdutoRepository
    {
        Task<List<Produto>> ObterProdutosAVenda();
        Task<Produto> ObterPorId(Guid id);
        Task<bool> AdicionarProduto(Produto produto);
        Task<bool> AdicionarCategoria(Categoria categoria);
        void AtualizarProduto(Produto produto);
    }
}
