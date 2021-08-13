using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoLivraria.Repository.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LIVROS",
                columns: table => new
                {
                    IDLIVRO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    AUTOR = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DATAPUBLICACAO = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LIVROS", x => x.IDLIVRO);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LIVROS_ISBN",
                table: "LIVROS",
                column: "ISBN",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LIVROS");
        }
    }
}
