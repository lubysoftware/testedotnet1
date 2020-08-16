using Microsoft.EntityFrameworkCore.Migrations;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class Inclusãodedatasdecriaçãoeseativosnasclasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeDoProjeto",
                table: "Projetos");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Projetos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Projetos",
                nullable: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Desenvolvedores",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Projetos");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<string>(
                name: "NomeDoProjeto",
                table: "Projetos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
