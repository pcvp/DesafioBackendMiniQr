using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackendMiniQrApi.Data.Migrations
{
    public partial class Createuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "MiniQr",
                table: "Charges",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "MiniQr",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_UserId",
                schema: "MiniQr",
                table: "Charges",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "MiniQr",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Users_UserId",
                schema: "MiniQr",
                table: "Charges",
                column: "UserId",
                principalSchema: "MiniQr",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Users_UserId",
                schema: "MiniQr",
                table: "Charges");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "MiniQr");

            migrationBuilder.DropIndex(
                name: "IX_Charges_UserId",
                schema: "MiniQr",
                table: "Charges");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "MiniQr",
                table: "Charges");
        }
    }
}
