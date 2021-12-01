using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Data.Migrations
{
    public partial class ingredientModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "Unit",
                table: "Ingredient");

            migrationBuilder.AddColumn<string>(
                name: "ingredient",
                table: "Ingredient",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ingredient",
                table: "Ingredient");

            migrationBuilder.AddColumn<double>(
                name: "Amount",
                table: "Ingredient",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit",
                table: "Ingredient",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
