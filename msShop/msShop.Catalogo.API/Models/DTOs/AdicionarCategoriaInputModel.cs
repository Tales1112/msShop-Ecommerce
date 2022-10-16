using msShop.Catalogo.API.Models;

namespace msShop.Catalogo.API.Controllers
{
    public class AdicionarCategoriaInputModel
    {
        public string CategoriaNome { get; set; }
        public string CategoriaDescricao { get; set; }

        public Categoria ToEntity() => new Categoria(CategoriaNome, CategoriaDescricao);
    }
}