using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class Criando_Table_Lancamento_de_Horas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LancamentoDeHoras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataDeInicio = table.Column<DateTime>(nullable: false),
                    DataFinal = table.Column<DateTime>(nullable: false),
                    ProjetoTrabalhadoId = table.Column<int>(nullable: true),
                    DesenvolvedorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoDeHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LancamentoDeHoras_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LancamentoDeHoras_Projetos_ProjetoTrabalhadoId",
                        column: x => x.ProjetoTrabalhadoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDeHoras_DesenvolvedorId",
                table: "LancamentoDeHoras",
                column: "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoDeHoras_ProjetoTrabalhadoId",
                table: "LancamentoDeHoras",
                column: "ProjetoTrabalhadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoDeHoras");
        }
    }
}
