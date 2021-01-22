using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class _8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDeHoras_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                column: "ProjetoTrabalhadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                column: "ProjetoTrabalhadoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoDeHoras_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropColumn(
                name: "ProjetoTrabalhadoId",
                table: "LancamentoDeHoras");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "LancamentoDeHoras",
                type: "int",
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
    }
}
