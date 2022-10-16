using mShop.Core.DomainObjects;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace msShop.Catalogo.API.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal ValorBruto { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUrl { get; private set; }
        public string ImagemThumbnailUrl { get; private set; }
        public bool Ativo { get; private set; }
        public bool emEstoque { get; private set; }
        [ForeignKey("CategoriaId")]
        public Guid CategoriaId { get; private set; }   
        public string Slug { get; private set; }
        public string Marca { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public int Largura { get; private set; }
        public int Altura { get; private set; }
        public int Comprimento { get; private set; }
        public int Peso { get; private set; }
        public string UnidadeMedida { get; private set; }
        public Categoria Categoria { get; private set; }


        protected Produto() {}

        public Produto(string nome, string descricao, decimal valorBruto, decimal preco, string imagemUrl,
                     string imagemThumbnailUrl, bool ativo, bool emEstoque, Guid categoriaId,
                     string slug, string marca, int quantidadeEstoque, int largura, int altura,
                     int comprimento, int peso, string unidadeMedida)
        {
            Nome = nome;
            Descricao = descricao;
            ValorBruto = valorBruto;
            Preco = preco;
            ImagemUrl = imagemUrl;
            ImagemThumbnailUrl = imagemThumbnailUrl;
            Ativo = ativo;
            this.emEstoque = emEstoque;
            CategoriaId = categoriaId;
            Slug = slug;
            Marca = marca;
            QuantidadeEstoque = quantidadeEstoque;
            Largura = largura;
            Altura = altura;
            Comprimento = comprimento;
            Peso = peso;
            UnidadeMedida = unidadeMedida;
        }

        public void RetirarEstoque(int quantidade)
        {
            if (QuantidadeEstoque >= quantidade)
                QuantidadeEstoque -= quantidade;
        }
        public bool EstaDisponivel(int quantidade)
        {
            return Ativo && QuantidadeEstoque >= quantidade;
        }
    }
}
