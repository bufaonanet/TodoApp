using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Todo.Domain.Infra.Migrations
{
    public partial class criacao_tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(160)", maxLength: 160, nullable: true),
                    bit = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    User = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDo_User",
                table: "ToDo",
                column: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDo");
        }
    }
}
