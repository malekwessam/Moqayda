using Microsoft.EntityFrameworkCore.Migrations;

namespace Moqayda.API.Migrations
{
    public partial class AddProductToSwap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductToSwap",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductToSwap",
                table: "Product");
        }
    }
}
