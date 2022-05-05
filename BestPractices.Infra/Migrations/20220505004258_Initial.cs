using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestPractices.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    birth_date = table.Column<DateTime>(type: "date", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    cpf = table.Column<string>(type: "varchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
