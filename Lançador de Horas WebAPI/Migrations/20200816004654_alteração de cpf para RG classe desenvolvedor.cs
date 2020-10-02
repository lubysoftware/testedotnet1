using Microsoft.EntityFrameworkCore.Migrations;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class alteraçãodecpfparaRGclassedesenvolvedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<int>(
                name: "RG",
                table: "Desenvolvedores",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RG",
                table: "Desenvolvedores");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Desenvolvedores",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
