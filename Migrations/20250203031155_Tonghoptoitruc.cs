using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Tonghoptoitruc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TongHopToiTruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ThietbiId = table.Column<int>(type: "int", nullable: false),
                    DonViSuDungId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MucDichSuDung = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopToiTruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopToiTruc_PhongBan_DonViSuDungId",
                        column: x => x.DonViSuDungId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopToiTruc_ToiTruc_ThietbiId",
                        column: x => x.ThietbiId,
                        principalTable: "ToiTruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

           

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_DonViSuDungId",
                table: "TongHopToiTruc",
                column: "DonViSuDungId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopToiTruc_ThietbiId",
                table: "TongHopToiTruc",
                column: "ThietbiId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TongHopToiTruc");

           
        }
    }
}
