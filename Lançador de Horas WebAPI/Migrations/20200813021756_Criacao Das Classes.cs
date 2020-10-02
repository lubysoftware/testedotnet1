using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class CriacaoDasClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeDoProjeto = table.Column<string>(nullable: true),
                    Custo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosDeHoras",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    TotalPausa = table.Column<TimeSpan>(nullable: false),
                    HoraFim = table.Column<TimeSpan>(nullable: false),
                    TotalHoraDia = table.Column<TimeSpan>(nullable: false),
                    DesenvolvedorID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosDeHoras", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RegistrosDeHoras_Desenvolvedores_DesenvolvedorID",
                        column: x => x.DesenvolvedorID,
                        principalTable: "Desenvolvedores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RegistrosDeHoras_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDeHoras_DesenvolvedorID",
                table: "RegistrosDeHoras",
                column: "DesenvolvedorID");

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosDeHoras_ProjetoID",
                table: "RegistrosDeHoras",
                column: "ProjetoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosDeHoras");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "Projetos");
        }
    }
}