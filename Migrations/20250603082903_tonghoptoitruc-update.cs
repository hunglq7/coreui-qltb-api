using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class tonghoptoitrucupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyBangTais_TongHopBangTai_TongHopBangTaiId",
                table: "NhatKyBangTais");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatKyBangTais",
                table: "NhatKyBangTais");

            migrationBuilder.RenameTable(
                name: "NhatKyBangTais",
                newName: "NhatKyBangTai");

            migrationBuilder.RenameIndex(
                name: "IX_NhatKyBangTais_TongHopBangTaiId",
                table: "NhatKyBangTai",
                newName: "IX_NhatKyBangTai_TongHopBangTaiId");

            migrationBuilder.AddColumn<bool>(
                name: "DuPhong",
                table: "TongHopToiTruc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "TinhTrangThietBi",
                table: "TongHopBangTai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "TongHopBangTai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ThongSoKyThuatBangTai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DonViTinh",
                table: "ThongSoKyThuatBangTai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DanhMucBangTai",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhatKyBangTai",
                table: "NhatKyBangTai",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ac3255a-4a55-45d7-8612-0b9d32cc4c10", "AQAAAAIAAYagAAAAEL9T7jaX1819xPkPvQ2neygcKBRY2t0IhAHTc3UX8A5IcYcEZUQNTzHINj63oexG/A==" });

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyBangTai_TongHopBangTai_TongHopBangTaiId",
                table: "NhatKyBangTai",
                column: "TongHopBangTaiId",
                principalTable: "TongHopBangTai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NhatKyBangTai_TongHopBangTai_TongHopBangTaiId",
                table: "NhatKyBangTai");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NhatKyBangTai",
                table: "NhatKyBangTai");

            migrationBuilder.DropColumn(
                name: "DuPhong",
                table: "TongHopToiTruc");

            migrationBuilder.RenameTable(
                name: "NhatKyBangTai",
                newName: "NhatKyBangTais");

            migrationBuilder.RenameIndex(
                name: "IX_NhatKyBangTai_TongHopBangTaiId",
                table: "NhatKyBangTais",
                newName: "IX_NhatKyBangTais_TongHopBangTaiId");

            migrationBuilder.AlterColumn<string>(
                name: "TinhTrangThietBi",
                table: "TongHopBangTai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "TongHopBangTai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NoiDung",
                table: "ThongSoKyThuatBangTai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DonViTinh",
                table: "ThongSoKyThuatBangTai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DanhMucBangTai",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NhatKyBangTais",
                table: "NhatKyBangTais",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42ed25cb-a462-4654-800c-ce19cef02797", "AQAAAAIAAYagAAAAEMNtd+WfMsr42ag9wevsD2ByE7vGbPdfbV/5Up2NRwaIgyp/CIYacfhFhwqw5mvACw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_NhatKyBangTais_TongHopBangTai_TongHopBangTaiId",
                table: "NhatKyBangTais",
                column: "TongHopBangTaiId",
                principalTable: "TongHopBangTai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
