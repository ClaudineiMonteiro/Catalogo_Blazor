using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Catalogo_Blazor.Server.Migrations
{
    public partial class criaRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36260b6c-f87a-4c1a-a884-b3b48ac94f2f", "1770d2c2-300d-41d6-b412-f78fee761af5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "642c9481-6efd-48c3-99b0-4339706eb88d", "0d114503-3b6b-4096-acc1-2542c93f5291", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36260b6c-f87a-4c1a-a884-b3b48ac94f2f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "642c9481-6efd-48c3-99b0-4339706eb88d");
        }
    }
}
