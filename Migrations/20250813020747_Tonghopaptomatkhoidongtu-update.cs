using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghopaptomatkhoidongtuupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "NhatkyAptomatKhoidongtu");

            migrationBuilder.DropForeignKey(
                name: "FK_NhatkyAptomatKhoidongtu_TongHopAptomatKhoidongtu_ThietBiId",
                table: "NhatkyAptomatKhoidongtu");

            migrationBuilder.DropForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatkyAptomatKhoidongtu",
                table: "NhatkyAptomatKhoidongtu");

            migrationBuilder.RenameTable(
                name: "NhatkyAptomatKhoidongtu",
                newName: "Nhatkyaptomatkhoidongtu");

            migrationBuilder.RenameColumn(
                name: "TinhTrang",
                table: "TongHopAptomatKhoidongtu",
                newName: "TinhTrangThietBi");

            migrationBuilder.RenameColumn(
                name: "ThietBiId",
                table: "Nhatkyaptomatkhoidongtu",
                newName: "TonghopaptomatkhoidongtuId");

            migrationBuilder.RenameIndex(
                name: "IX_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu",
                newName: "IX_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtuId");

            migrationBuilder.RenameIndex(
                name: "IX_NhatkyAptomatKhoidongtu_ThietBiId",
                table: "Nhatkyaptomatkhoidongtu",
                newName: "IX_Nhatkyaptomatkhoidongtu_TonghopaptomatkhoidongtuId");

            migrationBuilder.AlterColumn<int>(
                name: "ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "DuPhong",
                table: "TongHopAptomatKhoidongtu",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MaQuanLy",
                table: "TongHopAptomatKhoidongtu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SoLuong",
                table: "TongHopAptomatKhoidongtu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Nhatkyaptomatkhoidongtu",
                table: "Nhatkyaptomatkhoidongtu",
                column: "Id");

            

            migrationBuilder.AddForeignKey(
                name: "FK_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu",
                column: "ThongsoAptomatKhoidongtuId",
                principalTable: "ThongsoAptomatKhoidongtu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Nhatkyaptomatkhoidongtu_TongHopAptomatKhoidongtu_TonghopaptomatkhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu",
                column: "TonghopaptomatkhoidongtuId",
                principalTable: "TongHopAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                column: "ThietBiId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu");

            migrationBuilder.DropForeignKey(
                name: "FK_Nhatkyaptomatkhoidongtu_TongHopAptomatKhoidongtu_TonghopaptomatkhoidongtuId",
                table: "Nhatkyaptomatkhoidongtu");

            migrationBuilder.DropForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Nhatkyaptomatkhoidongtu",
                table: "Nhatkyaptomatkhoidongtu");

            migrationBuilder.DropColumn(
                name: "DuPhong",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropColumn(
                name: "MaQuanLy",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropColumn(
                name: "SoLuong",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.DropColumn(
                name: "aptomatkhoidongtuId",
                table: "TongHopAptomatKhoidongtu");

            migrationBuilder.RenameTable(
                name: "Nhatkyaptomatkhoidongtu",
                newName: "NhatkyAptomatKhoidongtu");

            migrationBuilder.RenameColumn(
                name: "TinhTrangThietBi",
                table: "TongHopAptomatKhoidongtu",
                newName: "TinhTrang");

            migrationBuilder.RenameColumn(
                name: "TonghopaptomatkhoidongtuId",
                table: "NhatkyAptomatKhoidongtu",
                newName: "ThietBiId");

            migrationBuilder.RenameIndex(
                name: "IX_Nhatkyaptomatkhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "NhatkyAptomatKhoidongtu",
                newName: "IX_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtuId");

            migrationBuilder.RenameIndex(
                name: "IX_Nhatkyaptomatkhoidongtu_TonghopaptomatkhoidongtuId",
                table: "NhatkyAptomatKhoidongtu",
                newName: "IX_NhatkyAptomatKhoidongtu_ThietBiId");

            migrationBuilder.AlterColumn<int>(
                name: "ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhatkyAptomatKhoidongtu",
                table: "NhatkyAptomatKhoidongtu",
                column: "Id");
            

            migrationBuilder.AddForeignKey(
                name: "FK_NhatkyAptomatKhoidongtu_ThongsoAptomatKhoidongtu_ThongsoAptomatKhoidongtuId",
                table: "NhatkyAptomatKhoidongtu",
                column: "ThongsoAptomatKhoidongtuId",
                principalTable: "ThongsoAptomatKhoidongtu",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NhatkyAptomatKhoidongtu_TongHopAptomatKhoidongtu_ThietBiId",
                table: "NhatkyAptomatKhoidongtu",
                column: "ThietBiId",
                principalTable: "TongHopAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TongHopAptomatKhoidongtu_DanhmucAptomatKhoidongtu_ThietBiId",
                table: "TongHopAptomatKhoidongtu",
                column: "ThietBiId",
                principalTable: "DanhmucAptomatKhoidongtu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
