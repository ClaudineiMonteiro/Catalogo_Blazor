using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo_Blazor.Server.Migrations
{
    public partial class ProdutoImagemUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IamagemUrl",
                table: "Produtos",
                newName: "ImagemUrl");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagemUrl",
                table: "Produtos",
                newName: "IamagemUrl");
        }
    }
}
