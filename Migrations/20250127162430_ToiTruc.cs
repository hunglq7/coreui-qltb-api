using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ToiTruc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToiTruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaQuanLy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MaHieu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TenLoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NuocSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HangSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NamSX = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CongSuat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DienAp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SoVongQuay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LucKeo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TocDoKeoCham = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TocDoKeoNhanh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    TrongLuongToi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KichThuocNgoaiHinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DuongKinhCap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ChieuDaiCapQuan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ApLucKhiNen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LuongKhiNenTieuHao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GiChu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToiTruc", x => x.Id);
                });

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToiTruc");

           
        }
    }
}
