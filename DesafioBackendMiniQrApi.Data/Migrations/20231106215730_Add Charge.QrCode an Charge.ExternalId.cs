using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioBackendMiniQrApi.Data.Migrations
{
    public partial class AddChargeQrCodeanChargeExternalId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                schema: "MiniQr",
                table: "Charges",
                type: "varchar(max)",
                unicode: false,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                schema: "MiniQr",
                table: "Charges",
                type: "varchar(max)",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalId",
                schema: "MiniQr",
                table: "Charges");

            migrationBuilder.AlterColumn<string>(
                name: "QrCode",
                schema: "MiniQr",
                table: "Charges",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldNullable: true);
        }
    }
}
