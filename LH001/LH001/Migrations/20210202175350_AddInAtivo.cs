using Microsoft.EntityFrameworkCore.Migrations;

namespace LH001.Migrations
{
    public partial class AddInAtivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InAtivo",
                table: "Tb_Projetos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "InAtivo",
                table: "Tb_Desenvolvedores_Projetos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InAtivo",
                table: "Tb_Projetos");

            migrationBuilder.DropColumn(
                name: "InAtivo",
                table: "Tb_Desenvolvedores_Projetos");
        }
    }
}
