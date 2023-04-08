using Microsoft.EntityFrameworkCore.Migrations;

namespace Moqayda.API.Migrations
{
    public partial class addColumnIsfavourite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Isfavourite",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isfavourite",
                table: "Product");
        }
    }
}
