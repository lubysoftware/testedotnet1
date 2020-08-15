using Microsoft.EntityFrameworkCore.Migrations;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class alteraçãonaclassedesenvolvedor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "RegistrosDeHoras",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Desenvolvedores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(14) CHARACTER SET utf8mb4",
                oldMaxLength: 14);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RegistrosDeHoras",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Desenvolvedores",
                type: "varchar(14) CHARACTER SET utf8mb4",
                maxLength: 14,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
