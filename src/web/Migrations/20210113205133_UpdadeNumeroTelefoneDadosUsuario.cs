using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Migrations
{
    public partial class UpdadeNumeroTelefoneDadosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodigoArea",
                table: "DadosUsuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroTelefone",
                table: "DadosUsuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoArea",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "NumeroTelefone",
                table: "DadosUsuario");
        }
    }
}
