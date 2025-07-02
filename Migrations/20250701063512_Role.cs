using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "DanhMucRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucRole", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "TongHopRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PhongBanId = table.Column<int>(type: "int", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    TinhTrangThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DuPhong = table.Column<bool>(type: "bit", nullable: false),
                    LamViec = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopRole_DanhMucRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "DanhMucRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopRole_PhongBan_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TongHopRole_PhongBanId",
                table: "TongHopRole",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopRole_RoleId",
                table: "TongHopRole",
                column: "RoleId");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "TongHopRole");
            migrationBuilder.DropTable(
            name: "DanhMucRole");


        }
    }
}
