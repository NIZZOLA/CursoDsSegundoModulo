using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleEFMysql.Migrations
{
    public partial class Insercaodeeditoranolivro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Editora",
                table: "Livros",
                maxLength: 50,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Editora",
                table: "Livros");
        }
    }
}
