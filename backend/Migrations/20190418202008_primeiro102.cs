using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class primeiro102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissoes_Clientes_ClienteIdCliente",
                table: "Profissoes");

            migrationBuilder.RenameColumn(
                name: "ClienteIdCliente",
                table: "Profissoes",
                newName: "profissaoId");

            migrationBuilder.RenameIndex(
                name: "IX_Profissoes_ClienteIdCliente",
                table: "Profissoes",
                newName: "IX_Profissoes_profissaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissoes_Clientes_profissaoId",
                table: "Profissoes",
                column: "profissaoId",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profissoes_Clientes_profissaoId",
                table: "Profissoes");

            migrationBuilder.RenameColumn(
                name: "profissaoId",
                table: "Profissoes",
                newName: "ClienteIdCliente");

            migrationBuilder.RenameIndex(
                name: "IX_Profissoes_profissaoId",
                table: "Profissoes",
                newName: "IX_Profissoes_ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Profissoes_Clientes_ClienteIdCliente",
                table: "Profissoes",
                column: "ClienteIdCliente",
                principalTable: "Clientes",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
