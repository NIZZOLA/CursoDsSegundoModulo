using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleEFMysql.Migrations
{
    public partial class correcaodeentidadecliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_ClienteModel_ClienteId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienteModel",
                table: "ClienteModel");

            migrationBuilder.RenameTable(
                name: "ClienteModel",
                newName: "Clientes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendas_Clientes_ClienteId",
                table: "Vendas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "ClienteModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienteModel",
                table: "ClienteModel",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendas_ClienteModel_ClienteId",
                table: "Vendas",
                column: "ClienteId",
                principalTable: "ClienteModel",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
