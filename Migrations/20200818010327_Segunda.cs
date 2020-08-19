using Microsoft.EntityFrameworkCore.Migrations;

namespace LancamentoHorasAPI.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Desenvolvedores_DesenvolvedorId",
                table: "Lancamentos");

            migrationBuilder.DropForeignKey(
                name: "FK_Lancamentos_Projetos_ProjetoId",
                table: "Lancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_DesenvolvedorId",
                table: "Lancamentos");

            migrationBuilder.DropIndex(
                name: "IX_Lancamentos_ProjetoId",
                table: "Lancamentos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_DesenvolvedorId",
                table: "Lancamentos",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lancamentos_ProjetoId",
                table: "Lancamentos",
                column: "ProjetoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Desenvolvedores_DesenvolvedorId",
                table: "Lancamentos",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lancamentos_Projetos_ProjetoId",
                table: "Lancamentos",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
