using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Dados.Base.Migrations
{
    public partial class ConfiguracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_Projetos_ProjetoId",
                table: "Desenvolvedores");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Desenvolvedores",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_Projetos_ProjetoId",
                table: "Desenvolvedores",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_Projetos_ProjetoId",
                table: "Desenvolvedores");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "Desenvolvedores",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_Projetos_ProjetoId",
                table: "Desenvolvedores",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
