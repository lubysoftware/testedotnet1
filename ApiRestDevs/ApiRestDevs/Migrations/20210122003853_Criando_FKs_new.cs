using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class Criando_FKs_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "DesenvolvedorId",
                table: "Desenvolvedores",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores",
                column: "DesenvolvedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores");

            migrationBuilder.DropIndex(
                name: "IX_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                type: "int",
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
    }
}
