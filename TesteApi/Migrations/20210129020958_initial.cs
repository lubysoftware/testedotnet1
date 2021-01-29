using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TesteApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorasTrabalhadas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DtInicio = table.Column<DateTime>(nullable: false),
                    DtFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasTrabalhadas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    HoraTrabalhadaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desenvolvedores_HorasTrabalhadas_HoraTrabalhadaId",
                        column: x => x.HoraTrabalhadaId,
                        principalTable: "HorasTrabalhadas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    DesenvolvedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Desenvolvedores_DesenvolvedorId",
                        column: x => x.DesenvolvedorId,
                        principalTable: "Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_HoraTrabalhadaId",
                table: "Desenvolvedores",
                column: "HoraTrabalhadaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_DesenvolvedorId",
                table: "Projetos",
                column: "DesenvolvedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Desenvolvedores");

            migrationBuilder.DropTable(
                name: "HorasTrabalhadas");
        }
    }
}
