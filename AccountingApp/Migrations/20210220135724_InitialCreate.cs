using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AccountingApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetaliiFactura",
                columns: table => new
                {
                    IdDetaliiFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    NumeProdus = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cantitate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PretUnitar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Valoare = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetaliiFactura", x => new { x.IdDetaliiFactura, x.IdLocatie });
                });

            migrationBuilder.CreateTable(
                name: "Facturi",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false),
                    IdLocatie = table.Column<int>(type: "int", nullable: false),
                    NumarFactura = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DataFactura = table.Column<DateTime>(type: "datetime", nullable: false),
                    NumeClient = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturi", x => new { x.IdFactura, x.IdLocatie });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiFactura");

            migrationBuilder.DropTable(
                name: "Facturi");
        }
    }
}
