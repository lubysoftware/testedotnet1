using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiLuby.Migrations
{
    public partial class InitialBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_DEVELOPER",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEVELOPER", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "TB_BANKOFHOURS",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoDeveloper = table.Column<int>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    FinalDate = table.Column<DateTime>(nullable: false),
                    TotalHours = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_BANKOFHOURS", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_TB_BANKOFHOURS_TB_DEVELOPER_CodigoDeveloper",
                        column: x => x.CodigoDeveloper,
                        principalTable: "TB_DEVELOPER",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_BANKOFHOURS_CodigoDeveloper",
                table: "TB_BANKOFHOURS",
                column: "CodigoDeveloper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_BANKOFHOURS");

            migrationBuilder.DropTable(
                name: "TB_DEVELOPER");
        }
    }
}
