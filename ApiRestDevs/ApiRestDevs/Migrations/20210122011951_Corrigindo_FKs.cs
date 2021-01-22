using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class Corrigindo_FKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "LancamentoDeHoras",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDeHoras_ProjetoId",
                table: "LancamentoDeHoras",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoId",
                table: "LancamentoDeHoras",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoDeHoras_ProjetoId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "LancamentoDeHoras");
        }
    }
}
