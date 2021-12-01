using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Data.Migrations
{
    public partial class recipeModelORM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instruction_RecipeID",
                table: "Instruction");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_RecipeID",
                table: "Instruction",
                column: "RecipeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Instruction_RecipeID",
                table: "Instruction");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient");

            migrationBuilder.CreateIndex(
                name: "IX_Instruction_RecipeID",
                table: "Instruction",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_RecipeID",
                table: "Ingredient",
                column: "RecipeID");
        }
    }
}
