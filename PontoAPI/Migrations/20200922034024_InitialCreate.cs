using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TabDesenvolvedor",
                columns: table => new
                {
                    DesenvolvedorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabDesenvolvedor", x => x.DesenvolvedorID);
                });

            migrationBuilder.CreateTable(
                name: "TabProjeto",
                columns: table => new
                {
                    ProjetoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProjeto = table.Column<string>(nullable: true),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabProjeto", x => x.ProjetoID);
                });

            migrationBuilder.CreateTable(
                name: "TabLancamento",
                columns: table => new
                {
                    LancamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesenvolvedorID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    HoraInicio = table.Column<DateTime>(nullable: false),
                    HoraFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabLancamento", x => x.LancamentoID);
                    table.ForeignKey(
                        name: "FK_TabLancamento_TabDesenvolvedor_DesenvolvedorID",
                        column: x => x.DesenvolvedorID,
                        principalTable: "TabDesenvolvedor",
                        principalColumn: "DesenvolvedorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TabLancamento_TabProjeto_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "TabProjeto",
                        principalColumn: "ProjetoID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TabLancamento_DesenvolvedorID",
                table: "TabLancamento",
                column: "DesenvolvedorID");

            migrationBuilder.CreateIndex(
                name: "IX_TabLancamento_ProjetoID",
                table: "TabLancamento",
                column: "ProjetoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabLancamento");

            migrationBuilder.DropTable(
                name: "TabDesenvolvedor");

            migrationBuilder.DropTable(
                name: "TabProjeto");
        }
    }
}
