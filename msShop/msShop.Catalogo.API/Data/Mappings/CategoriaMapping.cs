using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using msShop.Catalogo.API.Models;

namespace msShop.Catalogo.API.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CategoriaNome)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.Property(x => x.CategoriaDescricao)
                   .IsRequired()
                   .HasColumnType("varchar(500)");

            builder.ToTable("Categorias");
        }
    }
}
