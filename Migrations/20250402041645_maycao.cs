using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class maycao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhmucMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhmucMayCao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TongHopMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    MayCaoId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    ChieuDaiMay = table.Column<double>(type: "float", nullable: false),
                    SoLuongXich = table.Column<int>(type: "int", nullable: false),
                    SoLuongCauMang = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopMayCao_DanhmucMayCao_MayCaoId",
                        column: x => x.MayCaoId,
                        principalTable: "DanhmucMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopMayCao_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhatKyMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TongHopMayCaoId = table.Column<int>(type: "int", nullable: false),
                    NgayThang = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonVi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ViTri = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TrangThai = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhatKyMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhatKyMayCao_TongHopMayCao_TongHopMayCaoId",
                        column: x => x.TongHopMayCaoId,
                        principalTable: "TongHopMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongSoKyThuatMayCao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MayCaoId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NhatKyMayCaoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongSoKyThuatMayCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatMayCao_DanhmucMayCao_MayCaoId",
                        column: x => x.MayCaoId,
                        principalTable: "DanhmucMayCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongSoKyThuatMayCao_NhatKyMayCao_NhatKyMayCaoId",
                        column: x => x.NhatKyMayCaoId,
                        principalTable: "NhatKyMayCao",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f64370c3-6f49-45f4-b5e6-d58a91a0c28e", "AQAAAAIAAYagAAAAEDzLzx4TAfubDrPsOC5Wsj/9Aaetx9YlzGYHJEoy2PfXm/U5HNhbxDGmt883wadX/g==" });

            migrationBuilder.CreateIndex(
                name: "IX_NhatKyMayCao_TongHopMayCaoId",
                table: "NhatKyMayCao",
                column: "TongHopMayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatMayCao_MayCaoId",
                table: "ThongSoKyThuatMayCao",
                column: "MayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ThongSoKyThuatMayCao_NhatKyMayCaoId",
                table: "ThongSoKyThuatMayCao",
                column: "NhatKyMayCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayCao_DonViId",
                table: "TongHopMayCao",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopMayCao_MayCaoId",
                table: "TongHopMayCao",
                column: "MayCaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongSoKyThuatMayCao");

            migrationBuilder.DropTable(
                name: "NhatKyMayCao");

            migrationBuilder.DropTable(
                name: "TongHopMayCao");

            migrationBuilder.DropTable(
                name: "DanhmucMayCao");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2b2a8f6-154e-489f-b9d9-42ac8507abbb", "AQAAAAIAAYagAAAAEJh/Mue7bSBCflh6kE7f5Ia23/7/6ENOcEeYUkXdullxihjCVcV4MpfqM9YXmCC5RQ==" });
        }
    }
}
