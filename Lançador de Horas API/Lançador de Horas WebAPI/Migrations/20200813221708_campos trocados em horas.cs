using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lançador_de_Horas_WebAPI.Migrations
{
    public partial class campostrocadosemhoras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjetoID",
                table: "RegistrosDeHoras",
                newName: "ProjetoId");

            migrationBuilder.RenameColumn(
                name: "DesenvolvedorID",
                table: "RegistrosDeHoras",
                newName: "DesenvolvedorId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosDeHoras_ProjetoID",
                table: "RegistrosDeHoras",
                newName: "IX_RegistrosDeHoras_ProjetoId");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosDeHoras_DesenvolvedorID",
                table: "RegistrosDeHoras",
                newName: "IX_RegistrosDeHoras_DesenvolvedorId");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoId",
                table: "RegistrosDeHoras",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedorId",
                table: "RegistrosDeHoras",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosDeHoras_Desenvolvedores_DesenvolvedorId",
                table: "RegistrosDeHoras",
                column: "DesenvolvedorId",
                principalTable: "Desenvolvedores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosDeHoras_Projetos_ProjetoId",
                table: "RegistrosDeHoras",
                column: "ProjetoId",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProjetoId",
                table: "RegistrosDeHoras",
                newName: "ProjetoID");

            migrationBuilder.RenameColumn(
                name: "DesenvolvedorId",
                table: "RegistrosDeHoras",
                newName: "DesenvolvedorID");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosDeHoras_ProjetoId",
                table: "RegistrosDeHoras",
                newName: "IX_RegistrosDeHoras_ProjetoID");

            migrationBuilder.RenameIndex(
                name: "IX_RegistrosDeHoras_DesenvolvedorId",
                table: "RegistrosDeHoras",
                newName: "IX_RegistrosDeHoras_DesenvolvedorID");

            migrationBuilder.AlterColumn<int>(
                name: "ProjetoID",
                table: "RegistrosDeHoras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DesenvolvedorID",
                table: "RegistrosDeHoras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TotalPausa",
                table: "RegistrosDeHoras",
                type: "time(6)",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosDeHoras_Desenvolvedores_DesenvolvedorID",
                table: "RegistrosDeHoras",
                column: "DesenvolvedorID",
                principalTable: "Desenvolvedores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistrosDeHoras_Projetos_ProjetoID",
                table: "RegistrosDeHoras",
                column: "ProjetoID",
                principalTable: "Projetos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}