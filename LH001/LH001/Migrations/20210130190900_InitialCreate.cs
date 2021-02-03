using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LH001.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Desenvolvedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Desenvolvedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Desenvolvedores_Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tb_DesenvolvedorId = table.Column<int>(type: "int", nullable: false),
                    Tb_ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Desenvolvedores_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Desenvolvedores_Projetos_Tb_Desenvolvedores_Tb_DesenvolvedorId",
                        column: x => x.Tb_DesenvolvedorId,
                        principalTable: "Tb_Desenvolvedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Desenvolvedores_Projetos_Tb_Projetos_Tb_ProjetoId",
                        column: x => x.Tb_ProjetoId,
                        principalTable: "Tb_Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_LancamentosHoras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tb_Desenvolvedor_ProjetoId = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_LancamentosHoras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_LancamentosHoras_Tb_Desenvolvedores_Projetos_Tb_Desenvolvedor_ProjetoId",
                        column: x => x.Tb_Desenvolvedor_ProjetoId,
                        principalTable: "Tb_Desenvolvedores_Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Desenvolvedores_Projetos_Tb_DesenvolvedorId",
                table: "Tb_Desenvolvedores_Projetos",
                column: "Tb_DesenvolvedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Desenvolvedores_Projetos_Tb_ProjetoId",
                table: "Tb_Desenvolvedores_Projetos",
                column: "Tb_ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_LancamentosHoras_Tb_Desenvolvedor_ProjetoId",
                table: "Tb_LancamentosHoras",
                column: "Tb_Desenvolvedor_ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_LancamentosHoras");

            migrationBuilder.DropTable(
                name: "Tb_Desenvolvedores_Projetos");

            migrationBuilder.DropTable(
                name: "Tb_Desenvolvedores");

            migrationBuilder.DropTable(
                name: "Tb_Projetos");
        }
    }
}
