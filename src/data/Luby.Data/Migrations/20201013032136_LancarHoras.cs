using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Luby.Data.Migrations
{
    public partial class LancarHoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtFim",
                table: "ProjetoDesenvolvedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInicio",
                table: "ProjetoDesenvolvedores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtFim",
                table: "ProjetoDesenvolvedores");

            migrationBuilder.DropColumn(
                name: "DtInicio",
                table: "ProjetoDesenvolvedores");
        }
    }
}
