using mShop.Core.DomainObjects;
using System.Collections.Generic;

namespace msShop.Catalogo.API.Models
{
    public class Categoria : Entity
    {
        public string CategoriaNome { get; private set; }
        public string CategoriaDescricao { get; private set; }
        public List<Produto> Produtos { get; private set; }

        protected Categoria()  {}

        public Categoria(string categoriaNome, string categoriaDescricao)
        {
            CategoriaNome = categoriaNome;
            CategoriaDescricao = categoriaDescricao;
        }
    }
}
