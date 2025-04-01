using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class khoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DanhMucKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucKhoan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TongHopKhoan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhoanId = table.Column<int>(type: "int", nullable: false),
                    DonViId = table.Column<int>(type: "int", nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    NgayLap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViTriLapDat = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TinhTrangKyThuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TongHopKhoan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TongHopKhoan_DanhMucKhoan_KhoanId",
                        column: x => x.KhoanId,
                        principalTable: "DanhMucKhoan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TongHopKhoan_PhongBan_DonViId",
                        column: x => x.DonViId,
                        principalTable: "PhongBan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e965c873-357c-4e86-98fc-5eb02e8afc29", "AQAAAAIAAYagAAAAEN+2WypX7N/Lm3QBykO9TXJ9y0FiRzAtHSqVbl2Kni5l5Gff5gA+A1RaaiT9KwCGsQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoan_DonViId",
                table: "TongHopKhoan",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_TongHopKhoan_KhoanId",
                table: "TongHopKhoan",
                column: "KhoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TongHopKhoan");

            migrationBuilder.DropTable(
                name: "DanhMucKhoan");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "137d49f7-91ff-4600-b19a-e0ce1efd0bad", "AQAAAAIAAYagAAAAECEbqcJZpTmiOljrhqEUjsiGXwvvGcRXfnrWULkGKYcan77MnO5xJgwBPne4G3C9qQ==" });
        }
    }
}
