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
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
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
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TabProjeto", x => x.ProjetoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TabDesenvolvedor");

            migrationBuilder.DropTable(
                name: "TabProjeto");
        }
    }
}
