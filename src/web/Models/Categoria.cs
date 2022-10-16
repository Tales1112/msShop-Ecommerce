using System;
using System.Collections.Generic;

namespace msShop.Models
{
    public class Categoria
    {
        public Guid Id { get; set; }
        public string CategoriaNome { get;  set; }
        public string CategoriaDescricao { get;   set; }
        public List<Produto> produtos { get;  set; }
    }
}
