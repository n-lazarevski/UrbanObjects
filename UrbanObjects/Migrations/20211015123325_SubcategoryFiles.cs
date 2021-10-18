using Microsoft.EntityFrameworkCore.Migrations;

namespace UrbanObjects.Migrations
{
    public partial class SubcategoryFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "Subcategories",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "Subcategories");
        }
    }
}
