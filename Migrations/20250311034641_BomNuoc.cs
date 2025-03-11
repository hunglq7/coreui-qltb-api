using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class BomNuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhmucBomnuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucBomnuoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomNuocId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoBomNuoc_DanhmucBomnuoc_BomNuocId",
                        column: x => x.BomNuocId,
                        principalTable: "DanhmucBomnuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TongHopBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BomNuocId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopBomNuoc_DanhmucBomnuoc_BomNuocId",
                        column: x => x.BomNuocId,
                        principalTable: "DanhmucBomnuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopBomNuoc_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyBomNuoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopBomNuocId = table.Column<int>(type: "int", nullable: false),
                    Ngaythang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyBomNuoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyBomNuoc_TongHopBomNuoc_TongHopBomNuocId",
                        column: x => x.TongHopBomNuocId,
                        principalTable: "TongHopBomNuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyBomNuoc_TongHopBomNuocId",
                table: "NhatKyBomNuoc",
                column: "TongHopBomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoBomNuoc_BomNuocId",
                table: "ThongSoBomNuoc",
                column: "BomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBomNuoc_BomNuocId",
                table: "TongHopBomNuoc",
                column: "BomNuocId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopBomNuoc_DonViId",
                table: "TongHopBomNuoc",
                column: "DonViId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NhatKyBomNuoc");

            migrationBuilder.DropTable(
                name: "ThongSoBomNuoc");

            migrationBuilder.DropTable(
                name: "TongHopBomNuoc");

            migrationBuilder.DropTable(
                name: "DanhmucBomnuoc");

           
        }
    }
}
