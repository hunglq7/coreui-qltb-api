using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class bienapedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienapId",
                table: "ThongSoKyThuatBienAp");

            migrationBuilder.RenameColumn(
                name: "BienapId",
                table: "ThongSoKyThuatBienAp",
                newName: "BienApId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongSoKyThuatBienAp_BienapId",
                table: "ThongSoKyThuatBienAp",
                newName: "IX_ThongSoKyThuatBienAp_BienApId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7e384308-5b25-470d-b708-e31fa08d20e9", "AQAAAAIAAYagAAAAELpmaMY1/4flCxKoH8hNDIfMZAUnP2Pe/xB7Pow5l7siLMWuXugVdwQdFyeDskft7Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienApId",
                table: "ThongSoKyThuatBienAp",
                column: "BienApId",
                principalTable: "DanhmucBienap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienApId",
                table: "ThongSoKyThuatBienAp");

            migrationBuilder.RenameColumn(
                name: "BienApId",
                table: "ThongSoKyThuatBienAp",
                newName: "BienapId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongSoKyThuatBienAp_BienApId",
                table: "ThongSoKyThuatBienAp",
                newName: "IX_ThongSoKyThuatBienAp_BienapId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4b41cdb0-2ea4-4982-ba1c-ad637df06416", "AQAAAAIAAYagAAAAEAQl7h9UkW2UkI2xbquunH0/qcSO6od4ZZ+plkC+KjalOs4rlok/hDErWNiGhRDF4Q==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ThongSoKyThuatBienAp_DanhmucBienap_BienapId",
                table: "ThongSoKyThuatBienAp",
                column: "BienapId",
                principalTable: "DanhmucBienap",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
