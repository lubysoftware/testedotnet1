using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Desenvolvedores",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>("varchar(200)", nullable: false),
                    Email = table.Column<string>("varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Desenvolvedores", x => x.Id); });

            migrationBuilder.CreateTable(
                "Projetos",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>("varchar(200)", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Projetos", x => x.Id); });

            migrationBuilder.CreateTable(
                "Lancamentos",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HoraInicio = table.Column<DateTime>("TIMESTAMP", nullable: false),
                    HoraFim = table.Column<DateTime>("TIMESTAMP", nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DesenvolvedorId = table.Column<Guid>(nullable: true),
                    ProjetoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lancamentos", x => x.Id);
                    table.ForeignKey(
                        "FK_Lancamentos_Desenvolvedores_DesenvolvedorId",
                        x => x.DesenvolvedorId,
                        "Desenvolvedores",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Lancamentos_Projetos_ProjetoId",
                        x => x.ProjetoId,
                        "Projetos",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Lancamentos_DesenvolvedorId",
                "Lancamentos",
                "DesenvolvedorId");

            migrationBuilder.CreateIndex(
                "IX_Lancamentos_ProjetoId",
                "Lancamentos",
                "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Lancamentos");

            migrationBuilder.DropTable(
                "Desenvolvedores");

            migrationBuilder.DropTable(
                "Projetos");
        }
    }
}