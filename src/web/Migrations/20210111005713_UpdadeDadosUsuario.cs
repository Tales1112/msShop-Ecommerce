using Microsoft.EntityFrameworkCore.Migrations;

namespace msShop.Migrations
{
    public partial class UpdadeDadosUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "DadosUsuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "DadosUsuario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "DadosUsuario",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "DadosUsuario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "DadosUsuario");
        }
    }
}
