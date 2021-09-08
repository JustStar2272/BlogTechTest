using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogTechTest.Migrations
{
    public partial class TagsCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
               name: "Category",
               table: "Topics",
               nullable: true);

            migrationBuilder.AddColumn<string>(
               name: "Tags",
               table: "Topics",
               nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                 name: "Category",
                 table: "Topics");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Topics");
        }
    }
}
