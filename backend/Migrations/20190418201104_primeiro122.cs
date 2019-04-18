using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class primeiro122 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Profissoes_ProfissaoIdProfissao",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ProfissaoIdProfissao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "ProfissaoIdProfissao",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Profissoes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissoes_ClienteIdCliente",
                table: "Profissoes",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissoes_Clientes_ClienteIdCliente",
                table: "Profissoes",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissoes_Clientes_ClienteIdCliente",
                table: "Profissoes");

            migrationBuilder.DropIndex(
                name: "IX_Profissoes_ClienteIdCliente",
                table: "Profissoes");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Profissoes");

            migrationBuilder.AddColumn<int>(
                name: "ProfissaoIdProfissao",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ProfissaoIdProfissao",
                table: "Clientes",
                column: "ProfissaoIdProfissao");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Profissoes_ProfissaoIdProfissao",
                table: "Clientes",
                column: "ProfissaoIdProfissao",
                principalTable: "Profissoes",
                principalColumn: "IdProfissao",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
