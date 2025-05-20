using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class BangTai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenBangTai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucBangTai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BangTaiId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatBangTai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatBangTai_DanhMucBangTai_BangTaiId",
                        column: x => x.BangTaiId,
                        principalTable: "DanhMucBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TongHopBangTai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaHieu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BangTaiId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nmay = table.Column<int>(type: "int", nullable: false),
                    Lmay = table.Column<int>(type: "int", nullable: false),
                    KhungDau = table.Column<int>(type: "int", nullable: false),
                    KhungDuoi = table.Column<int>(type: "int", nullable: false),
                    KhungBangRoi = table.Column<int>(type: "int", nullable: false),
                    DayBang = table.Column<int>(type: "int", nullable: false),
                    ConLan = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopBangTai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopBangTai_DanhMucBangTai_BangTaiId",
                        column: x => x.BangTaiId,
                        principalTable: "DanhMucBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopBangTai_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyBangTais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopBangTaiId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyBangTais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyBangTais_TongHopBangTai_TongHopBangTaiId",
                        column: x => x.TongHopBangTaiId,
                        principalTable: "TongHopBangTai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "42ed25cb-a462-4654-800c-ce19cef02797", "AQAAAAIAAYagAAAAEMNtd+WfMsr42ag9wevsD2ByE7vGbPdfbV/5Up2NRwaIgyp/CIYacfhFhwqw5mvACw==" });

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyBangTais_TongHopBangTaiId",
                table: "NhatKyBangTais",
                column: "TongHopBangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatBangTai_BangTaiId",
                table: "ThongSoKyThuatBangTai",
                column: "BangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBangTai_BangTaiId",
                table: "TongHopBangTai",
                column: "BangTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBangTai_DonViId",
                table: "TongHopBangTai",
                column: "DonViId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatKyBangTais");

            migrationBuilder.DropTable(
                name: "ThongSoKyThuatBangTai");

            migrationBuilder.DropTable(
                name: "TongHopBangTai");

            migrationBuilder.DropTable(
                name: "DanhMucBangTai");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "003e4993-0031-4cd1-b142-85a0670c0d5e", "AQAAAAIAAYagAAAAECjQwI9gC5sZs86U3/ZphOiaAr2WHxl+9WSHnS4QQzPrBIw9IZWJ2pZk6b2FjK3NZA==" });
        }
    }
}
