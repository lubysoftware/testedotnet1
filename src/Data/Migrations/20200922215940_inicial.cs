using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    City = table.Column<string>(type: "varchar(200)", nullable: false),
                    State = table.Column<string>(type: "varchar(200)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedor", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desenvolvedor");
        }
    }
}
