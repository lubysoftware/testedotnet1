using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class _20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "varchar(20)",
                nullable: true,
                defaultValue: "all",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true,
                oldDefaultValue: "all");
        }
    }
}
