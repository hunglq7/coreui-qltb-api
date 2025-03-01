using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghoptoitrucedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TongHopToiTruc_ToiTruc_ThietbiId",
                table: "TongHopToiTruc");

            migrationBuilder.AddColumn<int>(
                name: "ToiTrucId",
                table: "TongHopToiTruc",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "49da8dea-ce91-4f4c-b217-4fa194a7b0ad", "AQAAAAIAAYagAAAAEPfHUtLdnO4CxDzOMI9DfPzDc/kgjb9K4MnHprgtzDWVYPKRKXIc32cr1gTUSTpG/A==" });

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_ToiTrucId",
                table: "TongHopToiTruc",
                column: "ToiTrucId");

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopToiTruc_Danhmuctoitruc_ThietbiId",
                table: "TongHopToiTruc",
                column: "ThietbiId",
                principalTable: "Danhmuctoitruc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopToiTruc_ToiTruc_ToiTrucId",
                table: "TongHopToiTruc",
                column: "ToiTrucId",
                principalTable: "ToiTruc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TongHopToiTruc_Danhmuctoitruc_ThietbiId",
                table: "TongHopToiTruc");

            migrationBuilder.DropForeignKey(
                name: "FK_TongHopToiTruc_ToiTruc_ToiTrucId",
                table: "TongHopToiTruc");

            migrationBuilder.DropIndex(
                name: "IX_TongHopToiTruc_ToiTrucId",
                table: "TongHopToiTruc");

            migrationBuilder.DropColumn(
                name: "ToiTrucId",
                table: "TongHopToiTruc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71d92a7a-ffa2-429a-8ed5-45d3d6345130", "AQAAAAIAAYagAAAAELzMcvE8n946K9TDY34EQOrSn+JnBfxssY5RMZmdl3GD6WMfC1Dnh1BdatSEQVo2VA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopToiTruc_ToiTruc_ThietbiId",
                table: "TongHopToiTruc",
                column: "ThietbiId",
                principalTable: "ToiTruc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
