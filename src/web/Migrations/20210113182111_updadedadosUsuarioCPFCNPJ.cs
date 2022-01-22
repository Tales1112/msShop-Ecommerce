using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Migrations
{
    public partial class updadedadosUsuarioCPFCNPJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "DadosUsuario");

            migrationBuilder.AddColumn<string>(
                name: "CPFCNPJ",
                table: "DadosUsuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDocumento",
                table: "DadosUsuario",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPFCNPJ",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "DadosUsuario");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "DadosUsuario",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
