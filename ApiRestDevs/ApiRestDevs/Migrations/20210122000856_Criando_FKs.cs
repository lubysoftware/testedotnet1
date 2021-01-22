using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class Criando_FKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDeHoras_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedorId",
                table: "LancamentoDeHoras",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDeHoras_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoDeHoras",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_LancamentoDeHoras_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoDeHoras");

            migrationBuilder.DropForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedorId",
                table: "LancamentoDeHoras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDeHoras_Desenvolvedores_DesenvolvedorId",
                table: "LancamentoDeHoras",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                column: "ProjetoTrabalhadoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
