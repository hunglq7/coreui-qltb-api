using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Thongsoaptomatkhoidongtuupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_AptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu");

            migrationBuilder.RenameColumn(
                name: "AptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                newName: "DanhmucaptomatKhoidongtuId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongsoAptomatKhoidongtu_AptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                newName: "IX_ThongsoAptomatKhoidongtu_DanhmucaptomatKhoidongtuId");

           

            migrationBuilder.AddForeignKey(
                name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_DanhmucaptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                column: "DanhmucaptomatKhoidongtuId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_DanhmucaptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu");

            migrationBuilder.RenameColumn(
                name: "DanhmucaptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                newName: "AptomatKhoidongtuId");

            migrationBuilder.RenameIndex(
                name: "IX_ThongsoAptomatKhoidongtu_DanhmucaptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                newName: "IX_ThongsoAptomatKhoidongtu_AptomatKhoidongtuId");
            

            migrationBuilder.AddForeignKey(
                name: "FK_ThongsoAptomatKhoidongtu_DanhmucAptomatKhoidongtu_AptomatKhoidongtuId",
                table: "ThongsoAptomatKhoidongtu",
                column: "AptomatKhoidongtuId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
