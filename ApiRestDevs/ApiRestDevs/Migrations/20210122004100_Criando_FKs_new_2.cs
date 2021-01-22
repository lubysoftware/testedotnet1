using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiRestDevs.Migrations
{
    public partial class Criando_FKs_new_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desenvolvedores_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores");

            migrationBuilder.DropIndex(
                name: "IX_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores");

            migrationBuilder.DropColumn(
                name: "DesenvolvedorId",
                table: "Desenvolvedores");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DesenvolvedorId",
                table: "Desenvolvedores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores",
                column: "DesenvolvedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Desenvolvedores_Desenvolvedores_DesenvolvedorId",
                table: "Desenvolvedores",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
