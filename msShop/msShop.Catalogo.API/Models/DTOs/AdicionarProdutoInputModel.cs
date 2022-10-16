using msShop.Catalogo.API.Models;
using System;

namespace msShop.Catalogo.API.Controllers
{
    public class AdicionarProdutoInputModel
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal ValorBruto { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUrl { get; set; }
        public string ImagemThumbnailUrl { get; set; }
        public bool Ativo { get; set; }
        public bool emEstoque { get; set; }
        public Guid CategoriaId { get; set; }
        public string Slug { get; set; }
        public string Marca { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int Largura { get; set; }
        public int Altura { get; set; }
        public int Comprimento { get; set; }
        public int Peso { get; set; }
        public string UnidadeMedida { get; set; }


        public Produto ToEntity() => new Produto(Nome, Descricao, ValorBruto, Preco, ImagemUrl, ImagemThumbnailUrl, Ativo, emEstoque, CategoriaId,
                                                 Slug, Marca, QuantidadeEstoque, Largura, Altura, Comprimento, Peso, UnidadeMedida);
    }
}