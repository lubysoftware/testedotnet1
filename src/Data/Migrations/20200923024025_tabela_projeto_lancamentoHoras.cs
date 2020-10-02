using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class tabela_projeto_lancamentoHoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Concluido = table.Column<bool>(type: "bit", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "DateTime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LancamentoHora",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataHoraInicio = table.Column<DateTime>(type: "DateTime", nullable: false),
                    DataHoraFinal = table.Column<DateTime>(type: "DateTime", nullable: false),
                    IdProject = table.Column<Guid>(nullable: false),
                    IdDesenvolvedor = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LancamentoHora", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdDesenvolvedor",
                        column: x => x.IdDesenvolvedor,
                        principalTable: "Desenvolvedor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdProjeto",
                        column: x => x.IdProject,
                        principalTable: "Projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_IdDesenvolvedor",
                table: "LancamentoHora",
                column: "IdDesenvolvedor");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_IdProject",
                table: "LancamentoHora",
                column: "IdProject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LancamentoHora");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
