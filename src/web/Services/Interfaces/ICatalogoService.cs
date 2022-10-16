using msShop.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msShop.Services
{
    public interface ICatalogoService
    {
        Task<ProdutoViewModel> ObterPorId(Guid id);
        Task<List<ProdutoViewModel>> ObterTodos();
    }
}