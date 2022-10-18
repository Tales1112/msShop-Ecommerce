using Microsoft.AspNetCore.Mvc;
using mShop.WEbApi.Core.Controllers;
using msShop.Catalogo.API.Data.Repository;
using msShop.Catalogo.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace msShop.Catalogo.API.Controllers
{
    [ApiController]
    public class CatalogoController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;

        public CatalogoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("catalogo/AdicionarProduto")]
        public async Task<IActionResult> AdicionarProduto(AdicionarProdutoInputModel adicionarProdutoInputModel)
        {
            var result = await _produtoRepository.AdicionarProduto(adicionarProdutoInputModel.ToEntity());

            return CustomResponse(result);
        }

        [HttpGet("catalogo/produtos")]
        public async Task<List<Produto>> ObterProdutos()
        {
            return await _produtoRepository.ObterProdutosAVenda();
        }

        [HttpGet("catalogo/produtos/{id}")]
        public async Task<Produto> ProdutoDetalhe(Guid id)
        {
            return await _produtoRepository.ObterPorId(id);
        }

        [HttpPost("catalogo/AdicionarCategoria")]
        public async Task<IActionResult> AdicionarCategoria(AdicionarCategoriaInputModel adicionarCategoriaInputModel)
        {
            var result = await _produtoRepository.AdicionarCategoria(adicionarCategoriaInputModel.ToEntity());

            return CustomResponse(result);
        }
    }
}
