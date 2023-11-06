using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackendMiniQrApi.Data.Migrations
{
    public partial class CreateCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "MiniQr");

            migrationBuilder.CreateTable(
                name: "Charges",
                schema: "MiniQr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QrCode = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Charges",
                schema: "MiniQr");
        }
    }
}
