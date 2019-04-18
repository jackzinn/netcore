using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class fucnioncristo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissoes_Clientes_clienteIdCliente",
                table: "Profissoes");

            migrationBuilder.DropIndex(
                name: "IX_Profissoes_clienteIdCliente",
                table: "Profissoes");

            migrationBuilder.DropColumn(
                name: "clienteIdCliente",
                table: "Profissoes");

            migrationBuilder.AddColumn<int>(
                name: "profissao",
                table: "Clientes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_profissao",
                table: "Clientes",
                column: "profissao");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Profissoes_profissao",
                table: "Clientes",
                column: "profissao",
                principalTable: "Profissoes",
                principalColumn: "IdProfissao",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Profissoes_profissao",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_profissao",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "profissao",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "clienteIdCliente",
                table: "Profissoes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Profissoes_clienteIdCliente",
                table: "Profissoes",
                column: "clienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissoes_Clientes_clienteIdCliente",
                table: "Profissoes",
                column: "clienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
