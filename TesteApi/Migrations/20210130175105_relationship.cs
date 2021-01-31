using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteApi.Migrations
{
    public partial class relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_HorasTrabalhadas_HoraTrabalhadaId",
                table: "Desenvolvedores");

            migrationBuilder.DropForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedorId",
                table: "Projetos");

            migrationBuilder.DropIndex(
                name: "IX_Projetos_DesenvolvedorId",
                table: "Projetos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HorasTrabalhadas",
                table: "HorasTrabalhadas");

            migrationBuilder.DropIndex(
                name: "IX_Desenvolvedores_HoraTrabalhadaId",
                table: "Desenvolvedores");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "HorasTrabalhadas");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "HorasTrabalhadas");

            migrationBuilder.DropColumn(
                name: "HoraTrabalhadaId",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<int>(
                name: "ProjetoId",
                table: "HorasTrabalhadas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedorId",
                table: "HorasTrabalhadas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HorasTrabalhadas",
                table: "HorasTrabalhadas",
                columns: new[] { "ProjetoId", "DesenvolvedorId" });

            migrationBuilder.CreateIndex(
                name: "IX_HorasTrabalhadas_DesenvolvedorId",
                table: "HorasTrabalhadas",
                column: "DesenvolvedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorasTrabalhadas_Desenvolvedores_DesenvolvedorId",
                table: "HorasTrabalhadas",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorasTrabalhadas_Projetos_ProjetoId",
                table: "HorasTrabalhadas",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorasTrabalhadas_Desenvolvedores_DesenvolvedorId",
                table: "HorasTrabalhadas");

            migrationBuilder.DropForeignKey(
                name: "FK_HorasTrabalhadas_Projetos_ProjetoId",
                table: "HorasTrabalhadas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HorasTrabalhadas",
                table: "HorasTrabalhadas");

            migrationBuilder.DropIndex(
                name: "IX_HorasTrabalhadas_DesenvolvedorId",
                table: "HorasTrabalhadas");

            migrationBuilder.DropColumn(
                name: "ProjetoId",
                table: "HorasTrabalhadas");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "HorasTrabalhadas");

            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedorId",
                table: "Projetos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "HorasTrabalhadas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "HorasTrabalhadas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoraTrabalhadaId",
                table: "Desenvolvedores",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HorasTrabalhadas",
                table: "HorasTrabalhadas",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_DesenvolvedorId",
                table: "Projetos",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_HoraTrabalhadaId",
                table: "Desenvolvedores",
                column: "HoraTrabalhadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_HorasTrabalhadas_HoraTrabalhadaId",
                table: "Desenvolvedores",
                column: "HoraTrabalhadaId",
                principalTable: "HorasTrabalhadas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projetos_Desenvolvedores_DesenvolvedorId",
                table: "Projetos",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
