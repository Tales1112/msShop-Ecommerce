using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Migrations
{
    public partial class DadosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DadosUsuario",
                columns: table => new
                {
                    DadosUsuarioId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Enderenco = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Bairro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Complemento = table.Column<string>(nullable: true),
                    CEP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosUsuario", x => x.DadosUsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DadosUsuario");
        }
    }
}
