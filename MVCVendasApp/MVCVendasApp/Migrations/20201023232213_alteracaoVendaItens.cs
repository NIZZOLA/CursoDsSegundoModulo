using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCVendasApp.Migrations
{
    public partial class alteracaoVendaItens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItens_Produto_LivroId",
                table: "VendaItens");

            migrationBuilder.DropIndex(
                name: "IX_VendaItens_LivroId",
                table: "VendaItens");

            migrationBuilder.DropColumn(
                name: "LivroId",
                table: "VendaItens");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_ProdutoId",
                table: "VendaItens",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItens_Produto_ProdutoId",
                table: "VendaItens",
                column: "ProdutoId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendaItens_Produto_ProdutoId",
                table: "VendaItens");

            migrationBuilder.DropIndex(
                name: "IX_VendaItens_ProdutoId",
                table: "VendaItens");

            migrationBuilder.AddColumn<int>(
                name: "LivroId",
                table: "VendaItens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VendaItens_LivroId",
                table: "VendaItens",
                column: "LivroId");

            migrationBuilder.AddForeignKey(
                name: "FK_VendaItens_Produto_LivroId",
                table: "VendaItens",
                column: "LivroId",
                principalTable: "Produto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
