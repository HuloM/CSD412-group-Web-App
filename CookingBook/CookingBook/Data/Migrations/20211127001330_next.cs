using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Data.Migrations
{
    public partial class next : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Instruction",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Instruction",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RecipeID",
                table: "Ingredient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Recipe_RecipeID",
                table: "Ingredient",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instruction_Recipe_RecipeID",
                table: "Instruction",
                column: "RecipeID",
                principalTable: "Recipe",
                principalColumn: "RecipeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
