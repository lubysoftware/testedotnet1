using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class Alteraçãoclassehoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHoraDia",
                table: "RegistrosDeHoras");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalHoras",
                table: "RegistrosDeHoras",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalHoras",
                table: "RegistrosDeHoras");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalHoraDia",
                table: "RegistrosDeHoras",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
