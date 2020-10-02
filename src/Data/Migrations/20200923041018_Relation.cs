using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LancamentoHora",
                table: "LancamentoHora");

            migrationBuilder.DropIndex(
                name: "IX_LancamentoHora_IdDesenvolvedor",
                table: "LancamentoHora");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LancamentoHora",
                table: "LancamentoHora",
                columns: new[] { "IdDesenvolvedor", "IdProject" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LancamentoHora",
                table: "LancamentoHora");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LancamentoHora",
                table: "LancamentoHora",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_LancamentoHora_IdDesenvolvedor",
                table: "LancamentoHora",
                column: "IdDesenvolvedor");
        }
    }
}
