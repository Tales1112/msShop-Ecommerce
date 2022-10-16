using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using msShop.Catalogo.API.Models;

namespace msShop.Catalogo.API.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(250)");

            builder.Property(x => x.Descricao)
                   .IsRequired()
                   .HasColumnType("varchar(1000)");

            builder.Property(x => x.ValorBruto)
                   .IsRequired()
                   .HasColumnType("decimal");

            builder.Property(x => x.Preco)
                   .IsRequired()
                   .HasColumnType("decimal");

            builder.Property(x => x.ImagemUrl)
                   .HasColumnType("varchar(500)");

            builder.Property(x => x.ImagemThumbnailUrl)
                   .HasColumnType("varchar(500)");

            builder.Property(x => x.Slug)
                   .HasColumnType("varchar(250)");

            builder.Property(x => x.Marca)
                   .HasColumnType("varchar(250)");

            builder.ToTable("Produtos");
        }
    }
}
