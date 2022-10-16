using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Catalogo.API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoriaNome = table.Column<string>(type: "varchar(250)", nullable: false),
                    CategoriaDescricao = table.Column<string>(type: "varchar(500)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(1000)", nullable: false),
                    ValorBruto = table.Column<decimal>(type: "decimal", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal", nullable: false),
                    ImagemUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    ImagemThumbnailUrl = table.Column<string>(type: "varchar(500)", nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    emEstoque = table.Column<bool>(nullable: false),
                    CategoriaId = table.Column<Guid>(nullable: false),
                    Slug = table.Column<string>(type: "varchar(250)", nullable: true),
                    Marca = table.Column<string>(type: "varchar(250)", nullable: true),
                    QuantidadeEstoque = table.Column<int>(nullable: false),
                    Largura = table.Column<int>(nullable: false),
                    Altura = table.Column<int>(nullable: false),
                    Comprimento = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    UnidadeMedida = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
