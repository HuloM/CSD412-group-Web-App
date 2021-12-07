using Microsoft.EntityFrameworkCore.Migrations;

namespace CookingBook.Data.Migrations
{
    public partial class ReAddDataProtection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Recipe",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Recipe");
        }
    }
}
