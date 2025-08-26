using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopaptomatkhoidongtuupdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropIndex(
                name: "IX_TongHopAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropColumn(
                name: "ThietBiId",
                table: "TongHopAptomatKhoidongtu");

           

            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu",
                column: "aptomatkhoidongtuId");

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu",
                column: "aptomatkhoidongtuId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropIndex(
                name: "IX_TongHopAptomatKhoidongtu_aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.AddColumn<int>(
                name: "ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                type: "int",
                nullable: true);

           

            migrationBuilder.CreateIndex(
                name: "IX_TongHopAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                column: "ThietBiId");

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                column: "ThietBiId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id");
        }
    }
}
