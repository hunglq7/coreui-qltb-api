using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Danhmuctoitruc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Danhmuctoitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenThietBi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LoaiThietBi = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NamSanXuat = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    HangSanXuat = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TinhTrang = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Danhmuctoitruc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ThongsokythuatToitruc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DanhmuctoitrucId = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    DonViTinh = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ThongSo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongsokythuatToitruc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThongsokythuatToitruc_Danhmuctoitruc_DanhmuctoitrucId",
                        column: x => x.DanhmuctoitrucId,
                        principalTable: "Danhmuctoitruc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71d92a7a-ffa2-429a-8ed5-45d3d6345130", "AQAAAAIAAYagAAAAELzMcvE8n946K9TDY34EQOrSn+JnBfxssY5RMZmdl3GD6WMfC1Dnh1BdatSEQVo2VA==" });

            migrationBuilder.CreateIndex(
                name: "IX_ThongsokythuatToitruc_DanhmuctoitrucId",
                table: "ThongsokythuatToitruc",
                column: "DanhmuctoitrucId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThongsokythuatToitruc");

            migrationBuilder.DropTable(
                name: "Danhmuctoitruc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a0cfb680-ebbf-4aee-8a63-68746358f13d", "AQAAAAIAAYagAAAAEG3b0guVnjzYXWTuYbiH+ySq7rWW4jyMC7Y02ldqeYxatw6Ewb8bHKONAqfgnLdrkw==" });
        }
    }
}
