using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QtdHorasTrabalhadas",
                table: "LancamentoDeHoras",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "QtdHorasTrabalhadas",
                table: "LancamentoDeHoras",
                type: "double",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
