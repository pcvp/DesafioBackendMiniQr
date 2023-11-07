using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackendMiniQrApi.Data.Migrations
{
    public partial class ChargeCancelledByUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CancelledByUserId",
                schema: "MiniQr",
                table: "Charges",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charges_CancelledByUserId",
                schema: "MiniQr",
                table: "Charges",
                column: "CancelledByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charges_Users_CancelledByUserId",
                schema: "MiniQr",
                table: "Charges",
                column: "CancelledByUserId",
                principalSchema: "MiniQr",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charges_Users_CancelledByUserId",
                schema: "MiniQr",
                table: "Charges");

            migrationBuilder.DropIndex(
                name: "IX_Charges_CancelledByUserId",
                schema: "MiniQr",
                table: "Charges");

            migrationBuilder.DropColumn(
                name: "CancelledByUserId",
                schema: "MiniQr",
                table: "Charges");
        }
    }
}
